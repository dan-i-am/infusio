//----------------------
// <auto-generated>
// </auto-generated>
//----------------------
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using LanguageExt;
using Newtonsoft.Json;

namespace Infusio.Http
{
    using static Prelude;
    using static Formatting;
    using static JsonConvert;

    public static class HttpSupport
    {
        public static Task<Either<InfusioError, T>> interpret<T>(InfusioOp<T> op, InfusioClient client) =>
            RunAsync(op, InfusioState.Create(useLogging: false), client).Match(
                Left: e => Left<InfusioError, T>(e),
                Right: r => r.Value
            );

        public static Task<Either<InfusioError, T>> Run<T>(this InfusioOp<T> op, InfusioClient client) =>
            RunAsync(op, InfusioState.Create(useLogging: false), client).Match(
                Left: e => Left<InfusioError, T>(e),
                Right: r => r.Value
            );

        public static Task<Either<InfusioError, InfusioResult<T>>> interpret<T>(InfusioOp<T> op, InfusioClient client, InfusioState state) =>
            RunAsync(op, state, client).ToEither();

        public static Task<Either<InfusioError, InfusioResult<T>>> Run<T>(this InfusioOp<T> op, InfusioClient client, InfusioState state) =>
            RunAsync(op, state, client).ToEither();

        public static Task<Either<InfusioError, InfusioResult<T>>> interpretWithLogs<T>(InfusioOp<T> op, InfusioClient client, IEnumerable<string> logs = default) =>
            RunAsync(op, InfusioState.Create(Seq(logs), useLogging: true), client).ToEither();

        public static Task<Either<InfusioError, InfusioResult<T>>> RunWithLogs<T>(this InfusioOp<T> op, InfusioClient client, IEnumerable<string> logs = default) =>
            RunAsync(op, InfusioState.Create(Seq(logs), useLogging: true), client).ToEither();

        static EitherAsync<InfusioError, InfusioResult<T>> RunAsync<T>(InfusioOp<T> op, InfusioState state, InfusioClient client) =>
            op is InfusioOp<T>.Return r ? Right<InfusioError, InfusioResult<T>>(new InfusioResult<T>(r.Value, state.Logs)).ToAsync() :
            op is InfusioOp<T>.Log l ? Exe(l, l, l.Next, state, client) :
            op is InfusioOp<T>.GetAccountProfile _1 ? Exe(_1, _1, _1.Next, state, client) :
            op is InfusioOp<T>.UpdateAccountInfo _2 ? Exe(_2, _2, _2.Next, state, client) :
            op is InfusioOp<T>.SearchCommissions _3 ? Exe(_3, _3, _3.Next, state, client) :
            op is InfusioOp<T>.RetrieveAffiliateModel _4 ? Exe(_4, _4, _4.Next, state, client) :
            op is InfusioOp<T>.ListAppointments _5 ? Exe(_5, _5, _5.Next, state, client) :
            op is InfusioOp<T>.CreateAppointment _6 ? Exe(_6, _6, _6.Next, state, client) :
            op is InfusioOp<T>.RetrieveAppointmentModel _7 ? Exe(_7, _7, _7.Next, state, client) :
            op is InfusioOp<T>.GetAppointment _8 ? Exe(_8, _8, _8.Next, state, client) :
            op is InfusioOp<T>.UpdateAppointment _9 ? Exe(_9, _9, _9.Next, state, client) :
            op is InfusioOp<T>.DeleteAppointment _10 ? Exe(_10, _10, _10.Next, state, client) :
            op is InfusioOp<T>.UpdatePropertiesOnAppointment _11 ? Exe(_11, _11, _11.Next, state, client) :
            op is InfusioOp<T>.ListCampaigns _12 ? Exe(_12, _12, _12.Next, state, client) :
            op is InfusioOp<T>.GetCampaign _13 ? Exe(_13, _13, _13.Next, state, client) :
            op is InfusioOp<T>.AddContactsToCampaignSequence _14 ? Exe(_14, _14, _14.Next, state, client) :
            op is InfusioOp<T>.RemoveContactsFromCampaignSequence _15 ? Exe(_15, _15, _15.Next, state, client) :
            op is InfusioOp<T>.AddContactToCampaignSequence _16 ? Exe(_16, _16, _16.Next, state, client) :
            op is InfusioOp<T>.RemoveContactFromCampaignSequence _17 ? Exe(_17, _17, _17.Next, state, client) :
            op is InfusioOp<T>.ListCompanies _18 ? Exe(_18, _18, _18.Next, state, client) :
            op is InfusioOp<T>.CreateCompany _19 ? Exe(_19, _19, _19.Next, state, client) :
            op is InfusioOp<T>.RetrieveCompanyModel _20 ? Exe(_20, _20, _20.Next, state, client) :
            op is InfusioOp<T>.ListContacts _21 ? Exe(_21, _21, _21.Next, state, client) :
            op is InfusioOp<T>.CreateContact _22 ? Exe(_22, _22, _22.Next, state, client) :
            op is InfusioOp<T>.CreateOrUpdateContact _23 ? Exe(_23, _23, _23.Next, state, client) :
            op is InfusioOp<T>.RetrieveContactModel _24 ? Exe(_24, _24, _24.Next, state, client) :
            op is InfusioOp<T>.DeleteContact _25 ? Exe(_25, _25, _25.Next, state, client) :
            op is InfusioOp<T>.UpdatePropertiesOnContact _26 ? Exe(_26, _26, _26.Next, state, client) :
            op is InfusioOp<T>.CreateCreditCard _27 ? Exe(_27, _27, _27.Next, state, client) :
            op is InfusioOp<T>.ListEmailsForContact _28 ? Exe(_28, _28, _28.Next, state, client) :
            op is InfusioOp<T>.CreateEmailForContact _29 ? Exe(_29, _29, _29.Next, state, client) :
            op is InfusioOp<T>.ListAppliedTags _30 ? Exe(_30, _30, _30.Next, state, client) :
            op is InfusioOp<T>.ApplyTagsToContactId _31 ? Exe(_31, _31, _31.Next, state, client) :
            op is InfusioOp<T>.RemoveTagsFromContact _32 ? Exe(_32, _32, _32.Next, state, client) :
            op is InfusioOp<T>.RemoveTagsFromContact2 _33 ? Exe(_33, _33, _33.Next, state, client) :
            op is InfusioOp<T>.GetContact _34 ? Exe(_34, _34, _34.Next, state, client) :
            op is InfusioOp<T>.ListEmails _35 ? Exe(_35, _35, _35.Next, state, client) :
            op is InfusioOp<T>.CreateEmail _36 ? Exe(_36, _36, _36.Next, state, client) :
            op is InfusioOp<T>.CreateEmails _37 ? Exe(_37, _37, _37.Next, state, client) :
            op is InfusioOp<T>.DeleteEmails _38 ? Exe(_38, _38, _38.Next, state, client) :
            op is InfusioOp<T>.GetEmail _39 ? Exe(_39, _39, _39.Next, state, client) :
            op is InfusioOp<T>.UpdateEmail _40 ? Exe(_40, _40, _40.Next, state, client) :
            op is InfusioOp<T>.DeleteEmail _41 ? Exe(_41, _41, _41.Next, state, client) :
            op is InfusioOp<T>.ListFiles _42 ? Exe(_42, _42, _42.Next, state, client) :
            op is InfusioOp<T>.CreateFile _43 ? Exe(_43, _43, _43.Next, state, client) :
            op is InfusioOp<T>.GetFile _44 ? Exe(_44, _44, _44.Next, state, client) :
            op is InfusioOp<T>.UpdateFile _45 ? Exe(_45, _45, _45.Next, state, client) :
            op is InfusioOp<T>.DeleteFile _46 ? Exe(_46, _46, _46.Next, state, client) :
            op is InfusioOp<T>.ListStoredHookSubscriptions _47 ? Exe(_47, _47, _47.Next, state, client) :
            op is InfusioOp<T>.CreateAHookSubscription _48 ? Exe(_48, _48, _48.Next, state, client) :
            op is InfusioOp<T>.ListHookEventTypes _49 ? Exe(_49, _49, _49.Next, state, client) :
            op is InfusioOp<T>.RetrieveAHookSubscription _50 ? Exe(_50, _50, _50.Next, state, client) :
            op is InfusioOp<T>.UpdateAHookSubscription _51 ? Exe(_51, _51, _51.Next, state, client) :
            op is InfusioOp<T>.DeleteAHookSubscription _52 ? Exe(_52, _52, _52.Next, state, client) :
            op is InfusioOp<T>.VerifyAHookSubscriptionDelayed _53 ? Exe(_53, _53, _53.Next, state, client) :
            op is InfusioOp<T>.VerifyAHookSubscription _54 ? Exe(_54, _54, _54.Next, state, client) :
            op is InfusioOp<T>.GetUserInfo _55 ? Exe(_55, _55, _55.Next, state, client) :
            op is InfusioOp<T>.ListOpportunities _56 ? Exe(_56, _56, _56.Next, state, client) :
            op is InfusioOp<T>.CreateOpportunity _57 ? Exe(_57, _57, _57.Next, state, client) :
            op is InfusioOp<T>.UpdateOpportunity _58 ? Exe(_58, _58, _58.Next, state, client) :
            op is InfusioOp<T>.RetrieveOpportunityModel _59 ? Exe(_59, _59, _59.Next, state, client) :
            op is InfusioOp<T>.GetOpportunity _60 ? Exe(_60, _60, _60.Next, state, client) :
            op is InfusioOp<T>.UpdatePropertiesOnOpportunity _61 ? Exe(_61, _61, _61.Next, state, client) :
            op is InfusioOp<T>.ListOpportunityStagePipelines _62 ? Exe(_62, _62, _62.Next, state, client) :
            op is InfusioOp<T>.ListOrders _63 ? Exe(_63, _63, _63.Next, state, client) :
            op is InfusioOp<T>.RetrieveOrderModel _64 ? Exe(_64, _64, _64.Next, state, client) :
            op is InfusioOp<T>.GetOrder _65 ? Exe(_65, _65, _65.Next, state, client) :
            op is InfusioOp<T>.ListTransactionsForOrder _66 ? Exe(_66, _66, _66.Next, state, client) :
            op is InfusioOp<T>.ListProducts _67 ? Exe(_67, _67, _67.Next, state, client) :
            op is InfusioOp<T>.CreateProduct _68 ? Exe(_68, _68, _68.Next, state, client) :
            op is InfusioOp<T>.ListProductsFromSyncToken _69 ? Exe(_69, _69, _69.Next, state, client) :
            op is InfusioOp<T>.RetrieveProduct _70 ? Exe(_70, _70, _70.Next, state, client) :
            op is InfusioOp<T>.DeleteProduct _71 ? Exe(_71, _71, _71.Next, state, client) :
            op is InfusioOp<T>.CreateProductSubscription _72 ? Exe(_72, _72, _72.Next, state, client) :
            op is InfusioOp<T>.RetrieveProductSubscription _73 ? Exe(_73, _73, _73.Next, state, client) :
            op is InfusioOp<T>.DeleteProductSubscription _74 ? Exe(_74, _74, _74.Next, state, client) :
            op is InfusioOp<T>.GetApplicationEnabled _75 ? Exe(_75, _75, _75.Next, state, client) :
            op is InfusioOp<T>.GetContactOptionTypes _76 ? Exe(_76, _76, _76.Next, state, client) :
            op is InfusioOp<T>.RetrieveSubscriptionModel _77 ? Exe(_77, _77, _77.Next, state, client) :
            op is InfusioOp<T>.ListTags _78 ? Exe(_78, _78, _78.Next, state, client) :
            op is InfusioOp<T>.CreateTag _79 ? Exe(_79, _79, _79.Next, state, client) :
            op is InfusioOp<T>.CreateTagCategory _80 ? Exe(_80, _80, _80.Next, state, client) :
            op is InfusioOp<T>.GetTag _81 ? Exe(_81, _81, _81.Next, state, client) :
            op is InfusioOp<T>.ListContactsForTagId _82 ? Exe(_82, _82, _82.Next, state, client) :
            op is InfusioOp<T>.ApplyTagToContactIds _83 ? Exe(_83, _83, _83.Next, state, client) :
            op is InfusioOp<T>.RemoveTagFromContactIds _84 ? Exe(_84, _84, _84.Next, state, client) :
            op is InfusioOp<T>.RemoveTagFromContactId _85 ? Exe(_85, _85, _85.Next, state, client) :
            op is InfusioOp<T>.ListTasks _86 ? Exe(_86, _86, _86.Next, state, client) :
            op is InfusioOp<T>.CreateTask _87 ? Exe(_87, _87, _87.Next, state, client) :
            op is InfusioOp<T>.RetrieveTaskModel _88 ? Exe(_88, _88, _88.Next, state, client) :
            op is InfusioOp<T>.ListTasksForCurrentUser _89 ? Exe(_89, _89, _89.Next, state, client) :
            op is InfusioOp<T>.GetTask _90 ? Exe(_90, _90, _90.Next, state, client) :
            op is InfusioOp<T>.UpdateTask _91 ? Exe(_91, _91, _91.Next, state, client) :
            op is InfusioOp<T>.DeleteTask _92 ? Exe(_92, _92, _92.Next, state, client) :
            op is InfusioOp<T>.UpdatePropertiesOnTask _93 ? Exe(_93, _93, _93.Next, state, client) :
            op is InfusioOp<T>.ListTransactions _94 ? Exe(_94, _94, _94.Next, state, client) :
            op is InfusioOp<T>.GetTransaction _95 ? Exe(_95, _95, _95.Next, state, client) :
            throw new NotSupportedException();

        static EitherAsync<InfusioError, InfusioResult<B>> Exe<T, B>(Show<InfusioOp<T>> show, HttpWorkflow<T> workflow, Func<T, InfusioOp<B>> nextOp, InfusioState state, InfusioClient client) =>
            from right in LogOperation(show, workflow, state, client).ToAsync()
            from next in RunAsync(nextOp(right.Value), right.State, client)
            select next;

        static Task<Either<InfusioError, (InfusioState State, T Value)>> LogOperation<T>(Show<InfusioOp<T>> show, HttpWorkflow<T> workflow, InfusioState state, InfusioClient client) =>
            from st in Right<InfusioError, (InfusioState, Unit)>((LogRequest(state, show), unit)).AsTask()
            from result in workflow(client).ToAsync().Match(
                Left: error => Left<InfusioError, (InfusioState, T)>(error),
                Right: value => Right<InfusioError, (InfusioState, T)>((LogResult(st.Item1, value), value))
            )
            select result;

        static InfusioState LogRequest<T>(InfusioState state, Show<InfusioOp<T>> show) =>
            state.UseLogging ? state.Log(show()) : state;

        static InfusioState LogResult<T>(InfusioState state, T value) =>
            typeof(T) == typeof(Unit) ? state :
            state.UseLogging ? state.Log($"OK: {SerializeObject(value, Indented)}") :
            state;

        public static Task<T> Unsafe<T>(this Task<Either<InfusioError, T>> self) =>
            self.ToAsync()
                .IfLeftAsync(e => throw new Exception(e.Value));
    }

    public class InfusioState
    {
        public readonly Seq<string> Logs;
        public readonly bool UseLogging;
        public static InfusioState Create(Seq<string> logs = default, bool useLogging = default) => new InfusioState(useLogging:useLogging, logs: logs);

        InfusioState(Seq<string> logs = default, bool useLogging = default)
        {
            Logs = logs;
            UseLogging = useLogging;
        }

        public InfusioState Log(string message) =>
            new InfusioState(Logs.Append(Seq1(message)), UseLogging);
    }
}