[CmdletBinding()]
param(
    [string]$Repo = "holly-hacker/dnSpy.Extension.HoLLy",
    [string]$OutputDir = "github-issues"
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

function Get-SafeFileName {
    param([Parameter(Mandatory = $true)][string]$Name)

    $safe = $Name
    foreach ($char in [System.IO.Path]::GetInvalidFileNameChars()) {
        $safe = $safe.Replace($char, "-")
    }

    $safe = [regex]::Replace($safe, "\s+", " ").Trim()
    $safe = $safe.Replace(":", " -")
    $safe = $safe.Trim(". ")
    if ([string]::IsNullOrWhiteSpace($safe)) {
        return "untitled"
    }

    if ($safe.Length -gt 120) {
        return $safe.Substring(0, 120).TrimEnd()
    }

    return $safe
}

function Format-NullableDate {
    param($Value)

    $candidate = @($Value)[0]

    if ($null -eq $candidate -or [string]::IsNullOrWhiteSpace([string]$candidate)) {
        return ""
    }

    if ($candidate -is [DateTimeOffset]) {
        return $candidate.ToString("yyyy-MM-dd HH:mm:ss zzz")
    }

    if ($candidate -is [DateTime]) {
        return ([DateTimeOffset]$candidate).ToString("yyyy-MM-dd HH:mm:ss zzz")
    }

    return ([DateTimeOffset]::Parse([string]$candidate)).ToString("yyyy-MM-dd HH:mm:ss zzz")
}

function ConvertTo-FlatJsonItems {
    param([Parameter(Mandatory = $true)][string]$Json)

    if ([string]::IsNullOrWhiteSpace($Json)) {
        return @()
    }

    $parsed = @($Json | ConvertFrom-Json)
    $items = New-Object System.Collections.Generic.List[object]

    foreach ($entry in $parsed) {
        if ($null -eq $entry) {
            continue
        }

        if ($entry -is [System.Array]) {
            foreach ($inner in $entry) {
                if ($null -ne $inner) {
                    $null = $items.Add($inner)
                }
            }
            continue
        }

        $null = $items.Add($entry)
    }

    foreach ($item in $items) {
        Write-Output $item
    }
}

function Get-IssueComments {
    param(
        [Parameter(Mandatory = $true)][string]$Repo,
        [Parameter(Mandatory = $true)][int]$IssueNumber
    )

    $json = gh api --paginate --slurp ("repos/{0}/issues/{1}/comments?per_page=100" -f $Repo, $IssueNumber)
    return @(ConvertTo-FlatJsonItems -Json $json)
}

function New-IssueMarkdown {
    param(
        [Parameter(Mandatory = $true)]$Issue,
        [AllowEmptyCollection()][object[]]$Comments = @()
    )

    $lines = New-Object System.Collections.Generic.List[string]
    $issueNumber = [int](@($Issue.number)[0])
    $issueTitle = [string](@($Issue.title)[0])
    $issueState = [string](@($Issue.state)[0])
    $issueAuthor = [string](@($Issue.user.login)[0])
    $issueUrl = [string](@($Issue.html_url)[0])
    $commentItems = @($Comments | Where-Object { $null -ne $_ })
    $labels = @(
        $Issue.labels |
        ForEach-Object { [string]$_.name } |
        Where-Object { -not [string]::IsNullOrWhiteSpace($_) }
    )

    $null = $lines.Add(("# Issue #{0}: {1}" -f $issueNumber, $issueTitle))
    $null = $lines.Add("")
    $null = $lines.Add(("- State: {0}" -f $issueState))
    $null = $lines.Add(("- Author: {0}" -f $issueAuthor))
    $null = $lines.Add(("- Created: {0}" -f (Format-NullableDate $Issue.created_at)))
    $null = $lines.Add(("- Updated: {0}" -f (Format-NullableDate $Issue.updated_at)))

    if (-not [string]::IsNullOrWhiteSpace([string]$Issue.closed_at)) {
        $null = $lines.Add(("- Closed: {0}" -f (Format-NullableDate $Issue.closed_at)))
    }

    if ($labels.Count -gt 0) {
        $null = $lines.Add(("- Labels: {0}" -f ($labels -join ", ")))
    }

    $null = $lines.Add(("- Comments: {0}" -f $commentItems.Count))
    $null = $lines.Add(("- URL: {0}" -f $issueUrl))
    $null = $lines.Add("")
    $null = $lines.Add("## Body")
    $null = $lines.Add("")

    $body = [string](@($Issue.body)[0])
    if ([string]::IsNullOrWhiteSpace($body)) {
        $null = $lines.Add("_No body_")
    }
    else {
        $null = $lines.Add($body.TrimEnd())
    }

    if ($commentItems.Count -gt 0) {
        $null = $lines.Add("")
        $null = $lines.Add("## Comments")

        foreach ($comment in $commentItems) {
            $null = $lines.Add("")
            $commentAuthor = [string](@($comment.user.login)[0])
            $null = $lines.Add(("### {0} on {1}" -f $commentAuthor, (Format-NullableDate $comment.created_at)))
            $null = $lines.Add("")

            $commentBody = [string]$comment.body
            if ([string]::IsNullOrWhiteSpace($commentBody)) {
                $null = $lines.Add("_No comment body_")
            }
            else {
                $null = $lines.Add($commentBody.TrimEnd())
            }
        }
    }

    return ($lines -join [Environment]::NewLine) + [Environment]::NewLine
}

if (-not (Test-Path -LiteralPath $OutputDir)) {
    New-Item -ItemType Directory -Path $OutputDir | Out-Null
}

$issuesJson = gh api --paginate --slurp ("repos/{0}/issues?state=all&per_page=100" -f $Repo)
$issues = @(
    @(ConvertTo-FlatJsonItems -Json $issuesJson) |
    Where-Object { -not ($_.PSObject.Properties.Name -contains "pull_request") }
)

foreach ($issue in $issues) {
    $issueNumber = [int](@($issue.number)[0])
    $issueCommentCount = [int](@($issue.comments)[0])
    $comments = if ($issueCommentCount -gt 0) {
        @(Get-IssueComments -Repo $Repo -IssueNumber $issueNumber)
    }
    else {
        @()
    }
    $issueTitle = [string](@($issue.title)[0])
    $fileName = "{0:D4} - {1}.md" -f $issueNumber, (Get-SafeFileName -Name $issueTitle)
    $path = Join-Path $OutputDir $fileName
    $content = New-IssueMarkdown -Issue $issue -Comments $comments
    Set-Content -LiteralPath $path -Value $content -Encoding UTF8
}

Write-Output ("EXPORTED={0}" -f $issues.Count)
Write-Output ("OUTPUT_DIR={0}" -f (Resolve-Path -LiteralPath $OutputDir).Path)
