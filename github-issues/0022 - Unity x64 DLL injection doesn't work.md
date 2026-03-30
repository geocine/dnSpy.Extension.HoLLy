# Issue #22: Unity x64 DLL injection doesn't work

- State: open
- Author: holly-hacker
- Created: 2019-07-22 12:59:29 +00:00
- Updated: 2019-07-22 13:12:27 +00:00
- Labels: bug, enhancement, help wanted
- Comments: 1
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/22

## Body

For some reason this crashes at `mono_assembly_load_from_full` for normal Mono and at `mono_image_open` for BleedingEdge Mono. Not sure why, since x64 Framework and x86  Unity work just fine.

Opening this so I can close #7.

## Comments

### holly-hacker on 2019-07-22 13:12:27 +00:00

Here is a minimal Unity game compiled for both x86 and x64 and both normal and BleedingEdge Mono: [on catbox.moe](https://files.catbox.moe/vn8p11.7z), [on filehost.net](https://filehost.net/d4d4876f437175cb), [on filedropper.com](http://www.filedropper.com/3dtestproject)

