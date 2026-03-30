# Issue #17: Some fields don't show as mapped

- State: open
- Author: holly-hacker
- Created: 2019-07-11 13:58:02 +00:00
- Updated: 2020-07-24 17:47:48 +00:00
- Labels: bug, area:sourcemap, needs more info
- Comments: 1
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/17

## Body

For some reason, references to fields in the same class may be of type MemberRefMD instead of FieldDef, causing the sourcemapper to not recognize it (IMemberRef is not mapped). This field was of type I[], which may be related.

## Comments

### holly-hacker on 2020-07-24 15:04:11 +00:00

Needs a better example, I don't know how to reproduce this anymore.

