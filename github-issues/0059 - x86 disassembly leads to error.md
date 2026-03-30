# Issue #59: x86 disassembly leads to error.

- State: closed
- Author: ElektroKill
- Created: 2021-01-11 19:22:01 +00:00
- Updated: 2021-02-13 12:32:58 +00:00
- Closed: 2021-02-13 12:32:58 +00:00
- Comments: 1
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/59

## Body

Hello,
when looking at a binary protected with a modified ConfuserEx I noticed that the mod developers have figured out how to cause a crash to occur when disassembling methods.

Steps to reproduce:
1. Download the attached [file.zip](https://github.com/HoLLy-HaCKeR/dnSpy.Extension.HoLLy/files/5797889/file.zip)
2. Go to method at 0x06000046
3. Try to disassemble and see the error.

Thanks in advance!

## Comments

### holly-hacker on 2021-02-13 12:32:58 +00:00

Closing for now as neither of us can reproduce this on master

