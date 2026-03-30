# Issue #29: Fix Echo using different version of Iced

- State: closed
- Author: holly-hacker
- Created: 2020-07-20 16:40:29 +00:00
- Updated: 2020-07-24 17:02:20 +00:00
- Closed: 2020-07-24 17:02:19 +00:00
- Comments: 0
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/29

## Body

Can be worked around by manually modifying the version of Iced echo uses.

Obvious fix is to submit a PR to echo to update the version of the dependency, but it may also be possible to remove the strong name signing requirement as a post-build step to prevent this from causing issues in the future.

