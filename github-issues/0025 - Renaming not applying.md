# Issue #25: Renaming not applying

- State: closed
- Author: dylanpdx
- Created: 2019-11-13 13:17:59 +00:00
- Updated: 2019-11-30 20:36:50 +00:00
- Closed: 2019-11-30 20:36:50 +00:00
- Comments: 1
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/25

## Body

Hello!

Whenever I rename anything in a DLL, the code decompiles again, but the item doesn't change names.

I'm using dnSpy v6.0.5 (.NET framework)

Also something interesting, if I "rename" some variables, the changes are reflected in the mappings xml, but as soon as I close and re-open dnSpy, and rename another item, the changes are reset

## Comments

### dylanpdx on 2019-11-30 20:36:50 +00:00

Whoops, sorry for this. Just realized you have to select "C# (w/ SourceMap)" as the decompiler.

