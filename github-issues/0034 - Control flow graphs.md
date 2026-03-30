# Issue #34: Control flow graphs

- State: closed
- Author: holly-hacker
- Created: 2020-07-24 20:35:44 +00:00
- Updated: 2020-08-19 17:44:30 +00:00
- Closed: 2020-07-25 22:49:15 +00:00
- Labels: enhancement
- Comments: 1
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/34

## Body

With Echo, we can create control flow graphs similar to what IDA Pro does.

Current progress (will be expanded later):
- [x] Create Control Flow Graph display for managed methods
- [x] Create Control Flow Graph display for native methods
- [x] Improve layout to appear more control-flow like
- [ ] Allow editing method by rightclicking a node
	- [ ] Should open instruction editor with the right instructions selected
	- [ ] Should automatically update the graph

## Comments

### holly-hacker on 2020-07-25 22:47:45 +00:00

Will keep other improvements for other issues.
Implemented in 79c823c4d70a9b3f89131e74f44e3fe7ff169072.

