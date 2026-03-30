# Issue #49: Disassembly of single jmp near instruction will (incorrectly?) read too many instructions

- State: open
- Author: holly-hacker
- Created: 2020-10-27 21:14:58 +00:00
- Updated: 2021-02-17 19:16:19 +00:00
- Labels: bug, needs more info
- Comments: 1
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/49

## Body

Not entirely sure if this is a bug on my part, a bug in echo, or no bug at all.

Example of incorrect disassembly:
```
000FB550 E9AB5A0400           jmp     near ptr 141000h

000FB555 48                   dec     eax
000FB556 FF2549522301         jmp     dword ptr ds:[1235249h]
```
For this sample, it seems only 1 instruction should be disassembled instead of multiple.

## Comments

### holly-hacker on 2021-02-17 19:15:47 +00:00

Needs a sample

