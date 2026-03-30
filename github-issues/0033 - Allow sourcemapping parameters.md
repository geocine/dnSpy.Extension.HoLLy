# Issue #33: Allow sourcemapping parameters

- State: open
- Author: holly-hacker
- Created: 2020-07-24 15:19:08 +00:00
- Updated: 2025-11-26 13:58:24 +00:00
- Labels: enhancement, area:sourcemap
- Comments: 2
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/33

## Body

Parameters are of reference type `dnlib.DotNet.Parameter` which includes a reference to its owner, meaning they can be mapped.

## Comments

### joosthoi1 on 2025-11-26 13:20:18 +00:00

Do you see no way to implement this? Or could it be possible?

### holly-hacker on 2025-11-26 13:58:24 +00:00

I'm currently not working on .NET reverse engineering so I haven't looked at this project in a few years. I think at this point the best way forward is to communicate with the dnSpyEx developer to either find a better way to do source mapping (compared to how it is currently implemented), or find a way to implement this upstream in dnSpyEx itself.

At any rate, I'd be surprised if this extension still worked with the latest version of dnSpyEx. I'll have some time, but I currently don't have much time and I'm not using Windows as my desktop operating system.

