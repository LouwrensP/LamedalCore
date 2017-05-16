# Setup
* You can include the library by using the [LamedalCore](http://www.nuget.org/packages/LamedalCore/) nuget package 
* PM> Install-Package LamedalCore
* [Project Wiki](https://sites.google.com/site/lamedalwiki/)

(Please note that the library is still in its starting phases. Radical design changes will occur between versions)

![Kiku](/pics/Setup1.png)
![Kiku](/pics/Setup2.png)

# Usage

Sample Startup class
-------------------------
```c#
using System;
using LamedalCore;

namespace ConsoleApplication
{
    public class Program
    {
        private static readonly LamedalCore_ _lamed = LamedalCore_.Instance;
        
        public static void Main(string[] args)
        {
            _lamed.About_();
            
            // Methods dot show more info
            // ==========================
            _lamed.lib.About.*

            // Console menthods
            // ================
            _lamed.lib.Command.*

        }
    }
}
```