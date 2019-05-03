using System;
using ObjCRuntime;

namespace QualtricsIos
{
    [Native]
    public enum TargetingResultStatus : long
    {
        Passed = 0,
        FailedLogic = 1,
        SampledOut = 2,
        MultipleDisplayPrevented = 3,
        Error = 4
    }
}
