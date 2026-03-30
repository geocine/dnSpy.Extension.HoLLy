# Issue #65: CFG Blocks can render outside the area dedicated to them

- State: closed
- Author: ElektroKill
- Created: 2021-02-13 12:42:47 +00:00
- Updated: 2023-01-20 19:21:11 +00:00
- Closed: 2023-01-20 19:21:11 +00:00
- Labels: bug, help wanted
- Comments: 1
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/65

## Body

When a CFG is created and then dragged it is possible for something like this to happen.
![image](https://user-images.githubusercontent.com/37494960/107850254-4f562380-6e01-11eb-9530-b0ecc49e52f6.png)

## Comments

### holly-hacker on 2021-02-13 15:01:37 +00:00

Most likely a bug within MSAGL itself, since the DockPanel parent of the graph is inside the area.

