# Issue #3: Allow user to enter arbitrary code to inject into the debuggee

- State: open
- Author: holly-hacker
- Created: 2019-07-07 00:35:50 +00:00
- Updated: 2020-10-24 09:06:22 +00:00
- Labels: enhancement, major-feature
- Comments: 1
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/3

## Body

Allow the user to enter code, which will get compiled into a temporary DLL and injected into the debugged process.

The user will be shown a C# editor (similar to the "Edit Method (C#)" command) with the following code:
```cs
using System;

namespace Injectable
{
	public static class Program
	{
		// Do not remove this method!
		public static int Main(string argument)
		{
			Main();
			return 0;
		}

		public static void Main()
		{
			// Enter your code here or in the method above.
		}
	}
}
```

This will only be useful if the user has access to static members inside the process.

Requires #2

## Comments

### holly-hacker on 2019-07-10 20:12:45 +00:00

Won't be doing this in v0.3.0, it requires a better understanding of WPF and the dnSpy codebase than I have right now.

