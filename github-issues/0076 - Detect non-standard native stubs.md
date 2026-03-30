# Issue #76: Detect non-standard native stubs

- State: open
- Author: holly-hacker
- Created: 2023-03-05 11:28:22 +00:00
- Updated: 2023-03-05 11:28:22 +00:00
- Labels: enhancement
- Comments: 0
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/76

## Body

Inspired by washi's blog post: https://washi.dev/blog/posts/entry-points/

When loading a managed executable, detect non-standard native stubs to warn the user of accidental native code execution when debugging. I am not sure what the best way to warn the user is yet, but I think warning before starting a debugging session and showing a warning in the treeview (new node?) are a good start.

Technical note: The end of the stub jumps into _CorDllMain. It needs to be verified that this is the correct _CorDllMain.

