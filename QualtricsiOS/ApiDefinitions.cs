using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using UserNotifications;
using WebKit;

namespace QualtricsIos
{
    // @interface InitializationResult : NSObject
    [BaseType(typeof(NSObject))]
    [Protocol]
    //[DisableDefaultCtor]
    public interface InitializationResult
    {
        // -(NSString * _Nullable)getMessage __attribute__((warn_unused_result));
        [NullAllowed, Export("getMessage")]

        string Message { get; }

        // -(BOOL)passed __attribute__((warn_unused_result));
        [Export("passed")]

        bool Passed { get; }
    }

    // @interface Properties : NSObject
    [BaseType(typeof(NSObject))]
    [Protocol]
    public interface Properties
    {
        // -(void)setStringWithString:(NSString * _Nonnull)string for:(NSString * _Nonnull)key;
        [Export("setStringWithString:for:")]
        void SetStringWithString(string @string, string key);

        // -(void)setNumberWithNumber:(double)number for:(NSString * _Nonnull)key;
        [Export("setNumberWithNumber:for:")]
        void SetNumberWithNumber(double number, string key);

        // -(void)setDateTimeFor:(NSString * _Nonnull)key;
        [Export("setDateTimeFor:")]
        void SetDateTimeFor(string key);
    }

    // @interface Qualtrics : NSObject
    [BaseType(typeof(NSObject))]
    [Protocol]
    [DisableDefaultCtor]
    public interface Qualtrics
    {
        // @property (readonly, nonatomic, strong, class) Qualtrics * _Nonnull shared;
        [Static]
        [Export("shared", ArgumentSemantic.Strong)]
        Qualtrics Shared { get; }

        // @property (readonly, nonatomic, strong) Properties * _Nonnull properties;
        [Export("properties", ArgumentSemantic.Strong)]
        Properties Properties { get; }

        // -(void)initializeWithBrandId:(NSString * _Nonnull)brandId zoneId:(NSString * _Nonnull)zoneId interceptId:(NSString * _Nonnull)interceptId completion:(void (^ _Nullable)(InitializationResult * _Nonnull))completion;
        [Export("initializeWithBrandId:zoneId:interceptId:completion:")]
        void InitializeWithBrandId(string brandId, string zoneId, string interceptId, [NullAllowed] Action<InitializationResult> completion);

        // -(void)evaluateTargetingLogicWithCompletion:(void (^ _Nonnull)(TargetingResult * _Nonnull))completion;
        [Export("evaluateTargetingLogicWithCompletion:")]
        void EvaluateTargetingLogicWithCompletion(Action<TargetingResultNew> completion);

        // -(BOOL)handleLocalNotificationWithResponse:(UNNotificationResponse * _Nonnull)response displayOn:(UIViewController * _Nonnull)viewController __attribute__((availability(ios, introduced=10.0))) __attribute__((warn_unused_result));
        //[iOS(10, 0)]
        [Export("handleLocalNotificationWithResponse:displayOn:")]
        bool HandleLocalNotificationWithResponse(UNNotificationResponse response, UIViewController viewController);

        // -(BOOL)handleLocalNotification:(UILocalNotification * _Nonnull)notification displayOn:(UIViewController * _Nonnull)viewController __attribute__((warn_unused_result));
        [Export("handleLocalNotification:displayOn:")]
        bool HandleLocalNotification(UILocalNotification notification, UIViewController viewController);

        // -(BOOL)displayWithViewController:(UIViewController * _Nonnull)viewController __attribute__((warn_unused_result));
        [Export("displayWithViewController:")]
        bool DisplayWithViewController(UIViewController viewController);

        // -(void)displayTargetWithTargetViewController:(UIViewController * _Nonnull)targetViewController targetUrl:(NSString * _Nonnull)targetUrl;
        [Export("displayTargetWithTargetViewController:targetUrl:")]
        void DisplayTargetWithTargetViewController(UIViewController targetViewController, string targetUrl);

        // -(BOOL)hide __attribute__((warn_unused_result));
        [Export("hide")]

        bool Hide { get; }

        // -(void)registerViewVisitWithViewName:(NSString * _Nonnull)viewName;
        [Export("registerViewVisitWithViewName:")]
        void RegisterViewVisitWithViewName(string viewName);

        // -(void)resetTimer;
        [Export("resetTimer")]
        void ResetTimer();

        // -(void)resetViewCounter;
        [Export("resetViewCounter")]
        void ResetViewCounter();
    }

    // @interface QualtricsSurveyViewController : UIViewController <WKScriptMessageHandler>
    [BaseType(typeof(UIViewController))]
    [Protocol]
    public interface QualtricsSurveyViewController : IWKScriptMessageHandler
    {
        // -(instancetype _Nonnull)initWithUrl:(NSString * _Nonnull)url __attribute__((objc_designated_initializer));
        [Export("initWithUrl:")]
        [DesignatedInitializer]
        IntPtr Constructor(string url);

        // -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));

        // comment or Uncomment when needed

        [Export("initWithCoder:")]
        [DesignatedInitializer]
        IntPtr ConstructorCoder(NSCoder aDecoder);

        // -(void)viewDidAppear:(BOOL)animated;
        [Export("viewDidAppear:")]
        void ViewDidAppear(bool animated);

        // -(void)viewWillTransitionToSize:(CGSize)size withTransitionCoordinator:(id<UIViewControllerTransitionCoordinator> _Nonnull)coordinator;
        [Export("viewWillTransitionToSize:withTransitionCoordinator:")]
        void ViewWillTransitionToSize(CGSize size, IUIViewControllerTransitionCoordinator coordinator);

        // -(void)userContentController:(WKUserContentController * _Nonnull)userContentController didReceiveScriptMessage:(WKScriptMessage * _Nonnull)message;
        [Export("userContentController:didReceiveScriptMessage:")]
        void UserContentController(WKUserContentController userContentController, WKScriptMessage message);
    }

    // @interface TargetingResult : NSObject
    [BaseType(typeof(NSObject))]
    [Protocol]
    [DisableDefaultCtor]
    public interface TargetingResultNew
    {
        // -(NSString * _Nullable)getSurveyUrl __attribute__((warn_unused_result));
        [NullAllowed, Export("getSurveyUrl")]

        string SurveyUrl { get; }

        // -(enum targetingResultStatus)getTargetingResult __attribute__((warn_unused_result));
        [Export("getTargetingResult")]

        TargetingResultStatus TargetingResult { get; }

        // -(BOOL)passed __attribute__((warn_unused_result));
        [Export("passed")]

        bool Passed { get; }

        // -(TargetingResultError * _Nullable)getError __attribute__((warn_unused_result));
        [NullAllowed, Export("getError")]

        TargetingResultError Error { get; }

        // -(void)recordImpression;
        [Export("recordImpression")]
        void RecordImpression();

        // -(void)recordClick;
        [Export("recordClick")]
        void RecordClick();
    }

    // @interface TargetingResultError : NSObject
    [BaseType(typeof(NSObject))]
    [Protocol]
    [DisableDefaultCtor]
    public interface TargetingResultError
    {
    }

}
