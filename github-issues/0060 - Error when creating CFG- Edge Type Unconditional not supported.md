# Issue #60: Error when creating CFG: Edge Type Unconditional not supported

- State: closed
- Author: ElektroKill
- Created: 2021-02-08 20:31:15 +00:00
- Updated: 2021-02-09 12:40:42 +00:00
- Closed: 2021-02-09 12:40:42 +00:00
- Labels: bug, good first issue
- Comments: 0
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/60

## Body

Hello,

While using the extension to view the CFG of a method to debug my code I ran into a problem. When creating the CFG the dnSpy extension throws an exception and complains that the ControlFlowEdgeType.Unconditional is not supported.
https://github.com/HoLLy-HaCKeR/dnSpy.Extension.HoLLy/blob/35c147277bb680b12863b6927e88a5d26ba637b3/dnSpy.Extension.HoLLy/ControlFlowGraph/GraphProvider.cs#L136

To reproduce please download the file provided and navigate to the method at token 0x06000017 and attempt to create a control flow graph.

[UnpackMe.zip](https://github.com/HoLLy-HaCKeR/dnSpy.Extension.HoLLy/files/5946656/UnpackMe.zip)

Thanks in advance!

