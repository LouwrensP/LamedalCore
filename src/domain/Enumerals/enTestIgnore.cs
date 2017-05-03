namespace LamedalCore.domain.Enumerals
{
    public enum enTestIgnore
    {
        /// <summary>The method is used for testing and is therfor not part of unit testing scope.</summary>
        CodeIsUsedForTesting,

        /// <summary>The method is short cut method and already tested and need not be bested again</summary>
        MethodIsShortCut,

        /// <summary>This is a frontend method that require user interaction. It is not part of unit testing scope</summary>
        FrontendCode,

        /// <summary>The class is node link and excluded from unit testing scope</summary>
        ClassIsNodeLink,

        /// <summary>The constructor is private and will therefor not be executed</summary>
        ConstructorIsPrivate,

        /// <summary>The code is generated</summary>
        CodeIsGenerated
    }
}