# Issue #32: Sourcemap does not use decompiler settings

- State: open
- Author: holly-hacker
- Created: 2020-07-24 15:11:57 +00:00
- Updated: 2020-07-24 15:43:19 +00:00
- Labels: bug, help wanted, area:sourcemap
- Comments: 0
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/32

## Body

Corrently the sourcemapping decompilers will use default settings, meaning that eg. compiler-generated classes will not be shown.

A solution would be to simply import `IDecompilerService` and get the real decompiler instances from there, but it doesn't seem to be created yet when decompilers are instantiated.

