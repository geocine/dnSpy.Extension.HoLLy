# Issue #38: Support IL2CPP metadata on native binaries

- State: open
- Author: holly-hacker
- Created: 2020-08-09 20:48:39 +00:00
- Updated: 2020-10-12 14:13:26 +00:00
- Labels: enhancement
- Comments: 2
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/38

## Body

The idea would be to allow the user to select a metadata.dat file for native binaries that would allow the file to be disassembled as if it was a IL binary, except all methods would be shown as native and would have to be disassembled with the native disassembler.

Main difficulties:
- Implement my own IL2CPP metadata parser (Il2CppDumper's code is absolutely awful)
- Figure out how to replicate dnSpy's assemblynodes for a native binary, after it was initially loaded
	- maybe make our own root node and load binary ourselves?
- Improve navigation for the disassembler, possibly using a custom content provider

## Comments

### holly-hacker on 2020-08-17 18:09:51 +00:00

Could be useful: https://github.com/djkaty/Il2CppInspector

### holly-hacker on 2020-10-12 14:13:26 +00:00

If this works out, I could look into doing the same for wasm modules

