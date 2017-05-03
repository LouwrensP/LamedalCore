using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

/*
Decimal   ASCII     Hex
0         control   00
1         control   01
2         control   02
3         control   03
4         control   04
5         control   05
6         control   06
7         control   07
8         control   08
9         \t        09
10        \n        0A
11        \v        0B
12        \f        0C
13        \r        0D
14        control   0E
15        control   0F
16        control   10
17        control   11
18        control   12
19        control   13
20        control   14
21        control   15
22        control   16
23        control   17
24        control   18
25        control   19
26        control   1A
27        control   1B
28        control   1C
29        control   1D
30        control   1E
31        control   1F
32        space     20
33        !         21
34        "         22
35        #         23
36        $         24
37        %         25
38        &         26
39        '         27
40        (         28
41        )         29
42        *         2A
43        +         2B
44        ,         2C
45        -         2D
46        .         2E
47        /         2F
48        0         30
49        1         31
50        2         32
51        3         33
52        4         34
53        5         35
54        6         36
55        7         37
56        8         38
57        9         39
58        :         3A
59        ;         3B
60        <         3C
61        =         3D
62        >         3E
63        ?         3F
64        @         40
65        A         41
66        B         42
67        C         43
68        D         44
69        E         45
70        F         46
71        G         47
72        H         48
73        I         49
74        J         4A
75        K         4B
76        L         4C
77        M         4D
78        N         4E
79        O         4F
80        P         50
81        Q         51
82        R         52
83        S         53
84        T         54
85        U         55
86        V         56
87        W         57
88        X         58
89        Y         59
90        Z         5A
91        [         5B
92        \         5C
93        ]         5D
94        ^         5E
95        _         5F
96        `         60
97        a         61
98        b         62
99        c         63
100       d         64
101       e         65
102       f         66
103       g         67
104       h         68
105       i         69
106       j         6A
107       k         6B
108       l         6C
109       m         6D
110       n         6E
111       o         6F
112       p         70
113       q         71
114       r         72
115       s         73
116       t         74
117       u         75
118       v         76
119       w         77
120       x         78
121       y         79
122       z         7A
123       {         7B
124       |         7C
125       }         7D
126       ~         7E
127       control   7F 
*/

namespace LamedalCore.Types.String
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_Action, DefaultType = typeof(string), GroupName = "Str")]
    public sealed class String_SpecialChar
    {
        #region private settings
        private char char_copyright = '\u00a9';
        private char char_cross = '\u2020';
        private char char_crossdouble = '\u2021';
        private char char_registered = '\u00ae';
        private char char_trademark = '\u2122';
        //private string func_alarm = "\a";
        private char func_alarm_ = '\u0007';
        //private string func_backspace = "\b";
        private char func_backspace_ = '\u0008';
        private char func_del = '\u007f';
        private char func_escape_ = '\u001B';
        private char func_tab_ = '\u0009';
        private char math_3quoter = '\u00be';
        private char math_degree = '\u00b0';
        private char math_division = '\u00f7';
        private char math_function = '\u0192';
        private char math_half = '\u00bd';
        private char math_plusMinus = '\u00b1';
        private char math_power2 = '\u00b2';
        private char math_power3 = '\u00b3';
        private char math_quoter = '\u00bc';
        private char money_cent = '\u00a2';
        private char money_euro = '\u20ac';
        private char money_pound = '\u00a3';
        private char money_yen = '\u00a5';
        //private char func_carriageReturn_ = '\u000D';
        //private string func_carriageReturn = "\r";

        //private char func_NewLine_ = '\u000A';
        //private string func_NewLine = "\n";
        //private string func_tab = "\t";
        //private char func_formfeed_ = '\u000c';  // \f
        //private string func_formfeed = "\f";
        #endregion


        /// <summary>
        /// Add copyright to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Char_Copyright(string line, int total = 1)
        {
            line += new string(char_copyright, total);
            return line;
        }

        /// <summary>
        /// Add cross to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Char_Cross(string line, int total = 1)
        {
            line += new string(char_cross, total);
            return line;
        }

        /// <summary>
        /// Add a double cross to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Char_CrossDouble(string line, int total = 1)
        {
            line += new string(char_crossdouble, total);
            return line;
        }

        /// <summary>
        /// Add registered to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Char_Registered(string line, int total = 1)
        {
            line += new string(char_registered, total);
            return line;
        }

        /// <summary>
        /// Add trademark to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Char_Trademark(string line, int total = 1)
        {
            line += new string(char_trademark, total);
            return line;
        }

        /// <summary>
        /// Add tab to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Function_Alarm(string line, int total = 1)
        {
            line += new string(func_alarm_, total);
            return line;
        }

        /// <summary>
        /// Add backspace to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Function_Backspace(string line, int total = 1)
        {
            line += new string(func_backspace_, total);
            return line;
        }
        /// <summary>
        /// Add del to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        [Test_IgnoreCoverage(enTestIgnore.FrontendCode)]
        public string Function_Del(string line, int total = 1)
        {
            line += new string(func_del, total);
            return line;
        }

        /// <summary>
        /// Add escape to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        [Test_IgnoreCoverage(enTestIgnore.FrontendCode)]
        public string Function_ESC(string line, int total = 1)
        {
            line += new string(func_escape_, total);
            return line;
        }

        /// <summary>
        /// Add enters to line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Function_NL(string line, int total = 1)
        {
            string result = line;
            for (int ii = 0; ii < total; ii++) result += Environment.NewLine;
            return result;
        }

        /// <summary>
        /// Add tab to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Function_TAB(string line, int total = 1)
        {
            line += new string(func_tab_, total);
            return line;
        }

        /// <summary>
        /// Add 3 quoters to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Math_QuoterOf3(string line, int total = 1)
        {
            line += new string(math_3quoter, total);
            return line;
        }

        /// <summary>
        /// Add a degree to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Math_Degree(string line, int total = 1)
        {
            line += new string(math_degree, total);
            return line;
        }

        /// <summary>
        /// Add a division sign to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Math_Division(string line, int total = 1)
        {
            line += new string(math_division, total);
            return line;
        }

        /// <summary>
        /// Add function to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Math_Function(string line, int total = 1)
        {
            line += new string(math_function, total);
            return line;
        }

        /// <summary>
        /// Add a half to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Math_Half(string line, int total = 1)
        {
            line += new string(math_half, total);
            return line;
        }

        /// <summary>
        /// Add plus minus to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Math_PlusMinus(string line, int total = 1)
        {
            line += new string(math_plusMinus, total);
            return line;
        }

        /// <summary>
        /// Add power 2 to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Math_Power2(string line, int total = 1)
        {
            line += new string(math_power2, total);
            return line;
        }

        /// <summary>
        /// Add power 3 to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Math_Power3(string line, int total = 1)
        {
            line += new string(math_power3, total);
            return line;
        }

        /// <summary>
        /// Add quoter to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Math_Quoter(string line, int total = 1)
        {
            line += new string(math_quoter, total);
            return line;
        }

        /// <summary>
        /// Add cent sign to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Money_Cent(string line, int total = 1)
        {
            line += new string(money_cent, total);
            return line;
        }

        /// <summary>
        /// Add euro sign to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Money_Euro(string line, int total = 1)
        {
            line += new string(money_euro, total);
            return line;
        }

        /// <summary>
        /// Add pound sign to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Money_Pound(string line, int total = 1)
        {
            line += new string(money_pound, total);
            return line;
        }

        /// <summary>
        /// Add yen sign to the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public string Money_Yen(string line, int total = 1)
        {
            line += new string(money_yen, total);
            return line;
        }

        /// <summary>Removes the special characters.</summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public string SpecialCharacters_Remove(string str)
        {
            var sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// Determines whether [has special chars] [the specified your string].
        /// </summary>
        /// <param name="yourString">Your string.</param>
        /// <returns></returns>
        public bool SpecialChars_Check(string yourString)
        {
            return yourString.Any(ch => !Char.IsLetterOrDigit(ch));
        }

        /// <summary>
        /// Determines whether [has special chars] [the specified your string].
        /// </summary>
        /// <param name="yourString">Your string.</param>
        /// <returns></returns>
        public bool SpecialChars_Check2(string yourString)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            return (!regexItem.IsMatch(yourString));
        }
    }
}
