using System;
using System.Threading.Tasks;
using LanguageExt;
using Newtonsoft.Json;

namespace Infusio.Http
{
    using static Prelude;
    using static Formatting;
    using static JsonConvert;

    public static class HttpSupport
    {
        public static Task<Either<InfusioError, InfusioResult<T>>> interpret<T>(InfusioOp<T> op, InfusioClient client, InfusioLogging logging = InfusioLogging.WithoutLogs) =>
            RunAsync(op, InfusioState.Create(logging), client).ToEither();

        public static Task<Either<InfusioError, InfusioResult<T>>> Run<T>(this InfusioOp<T> op, InfusioClient client, InfusioLogging logging = InfusioLogging.WithoutLogs) =>
            RunAsync(op, InfusioState.Create(logging), client).ToEither();

        static EitherAsync<InfusioError, InfusioResult<T>> RunAsync<T>(InfusioOp<T> op, InfusioState state, InfusioClient client) =>
            op is InfusioOp<T>.Return r ? Right<InfusioError, InfusioResult<T>>(new InfusioResult<T>(r.Value, state.Logs)).ToAsync() :
            op is InfusioOp<T>.Log l ? Exe(l, () => Right<InfusioError, Unit>(unit).AsTask(), l.Next, state, client) :
            op is InfusioOp<T>.GetAccountProfile _1 ? Exe(_1, () => client.GetAccountProfile(), _1.Next, state, client) :
            op is InfusioOp<T>.UpdateAccountInfo _2 ? Exe(_2, () => client.UpdateAccountInfo(_2.AccountInfo), _2.Next, state, client) :
            op is InfusioOp<T>.SearchCommissions _3 ? Exe(_3, () => client.SearchCommissions(_3.AffiliateId, _3.Offset, _3.Limit, _3.Until, _3.Since), _3.Next, state, client) :
            op is InfusioOp<T>.RetrieveAffiliateModel _4 ? Exe(_4, () => client.RetrieveAffiliateModel(), _4.Next, state, client) :
            op is InfusioOp<T>.ListAppointments _5 ? Exe(_5, () => client.ListAppointments(_5.ContactId, _5.Offset, _5.Limit, _5.Until, _5.Since), _5.Next, state, client) :
            op is InfusioOp<T>.CreateAppointment _6 ? Exe(_6, () => client.CreateAppointment(_6.Appointment), _6.Next, state, client) :
            op is InfusioOp<T>.RetrieveAppointmentModel _7 ? Exe(_7, () => client.RetrieveAppointmentModel(), _7.Next, state, client) :
            op is InfusioOp<T>.GetAppointment _8 ? Exe(_8, () => client.GetAppointment(_8.AppointmentId), _8.Next, state, client) :
            op is InfusioOp<T>.UpdateAppointment _9 ? Exe(_9, () => client.UpdateAppointment(_9.AppointmentDTO, _9.AppointmentId), _9.Next, state, client) :
            op is InfusioOp<T>.DeleteAppointment _10 ? Exe(_10, () => client.DeleteAppointment(_10.AppointmentId), _10.Next, state, client) :
            op is InfusioOp<T>.UpdatePropertiesOnAppointment _11 ? Exe(_11, () => client.UpdatePropertiesOnAppointment(_11.AppointmentDTO, _11.AppointmentId), _11.Next, state, client) :
            op is InfusioOp<T>.ListCampaigns _12 ? Exe(_12, () => client.ListCampaigns(_12.OrderDirection, _12.Order, _12.SearchText, _12.Offset, _12.Limit), _12.Next, state, client) :
            op is InfusioOp<T>.GetCampaign _13 ? Exe(_13, () => client.GetCampaign(_13.CampaignId, _13.OptionalProperties), _13.Next, state, client) :
            op is InfusioOp<T>.AddContactsToCampaignSequence _14 ? Exe(_14, () => client.AddContactsToCampaignSequence(_14.Ids, _14.SequenceId, _14.CampaignId), _14.Next, state, client) :
            op is InfusioOp<T>.RemoveContactsFromCampaignSequence _15 ? Exe(_15, () => client.RemoveContactsFromCampaignSequence(_15.Ids, _15.SequenceId, _15.CampaignId), _15.Next, state, client) :
            op is InfusioOp<T>.AddContactToCampaignSequence _16 ? Exe(_16, () => client.AddContactToCampaignSequence(_16.ContactId, _16.SequenceId, _16.CampaignId), _16.Next, state, client) :
            op is InfusioOp<T>.RemoveContactFromCampaignSequence _17 ? Exe(_17, () => client.RemoveContactFromCampaignSequence(_17.ContactId, _17.SequenceId, _17.CampaignId), _17.Next, state, client) :
            op is InfusioOp<T>.ListCompanies _18 ? Exe(_18, () => client.ListCompanies(_18.OptionalProperties, _18.OrderDirection, _18.Order, _18.CompanyName, _18.Offset, _18.Limit), _18.Next, state, client) :
            op is InfusioOp<T>.CreateCompany _19 ? Exe(_19, () => client.CreateCompany(_19.Company), _19.Next, state, client) :
            op is InfusioOp<T>.RetrieveCompanyModel _20 ? Exe(_20, () => client.RetrieveCompanyModel(), _20.Next, state, client) :
            op is InfusioOp<T>.ListContacts _21 ? Exe(_21, () => client.ListContacts(_21.OrderDirection, _21.Order, _21.FamilyName, _21.GivenName, _21.Email, _21.Offset, _21.Limit), _21.Next, state, client) :
            op is InfusioOp<T>.CreateContact _22 ? Exe(_22, () => client.CreateContact(_22.Contact), _22.Next, state, client) :
            op is InfusioOp<T>.CreateOrUpdateContact _23 ? Exe(_23, () => client.CreateOrUpdateContact(_23.Contact), _23.Next, state, client) :
            op is InfusioOp<T>.RetrieveContactModel _24 ? Exe(_24, () => client.RetrieveContactModel(), _24.Next, state, client) :
            op is InfusioOp<T>.DeleteContact _25 ? Exe(_25, () => client.DeleteContact(_25.ContactId), _25.Next, state, client) :
            op is InfusioOp<T>.UpdatePropertiesOnContact _26 ? Exe(_26, () => client.UpdatePropertiesOnContact(_26.ContactId, _26.Contact), _26.Next, state, client) :
            op is InfusioOp<T>.CreateCreditCard _27 ? Exe(_27, () => client.CreateCreditCard(_27.ContactId, _27.CreditCard), _27.Next, state, client) :
            op is InfusioOp<T>.ListEmailsForContact _28 ? Exe(_28, () => client.ListEmailsForContact(_28.ContactId, _28.Email, _28.ContactId2, _28.Offset, _28.Limit), _28.Next, state, client) :
            op is InfusioOp<T>.CreateEmailForContact _29 ? Exe(_29, () => client.CreateEmailForContact(_29.ContactId, _29.EmailWithContent), _29.Next, state, client) :
            op is InfusioOp<T>.ListAppliedTags _30 ? Exe(_30, () => client.ListAppliedTags(_30.ContactId, _30.Offset, _30.Limit), _30.Next, state, client) :
            op is InfusioOp<T>.ApplyTagsToContactId _31 ? Exe(_31, () => client.ApplyTagsToContactId(_31.TagIds, _31.ContactId), _31.Next, state, client) :
            op is InfusioOp<T>.RemoveTagsFromContact _32 ? Exe(_32, () => client.RemoveTagsFromContact(_32.Ids, _32.ContactId), _32.Next, state, client) :
            op is InfusioOp<T>.RemoveTagsFromContact2 _33 ? Exe(_33, () => client.RemoveTagsFromContact2(_33.TagId, _33.ContactId), _33.Next, state, client) :
            op is InfusioOp<T>.GetContact _34 ? Exe(_34, () => client.GetContact(_34.Id, _34.OptionalProperties), _34.Next, state, client) :
            op is InfusioOp<T>.ListEmails _35 ? Exe(_35, () => client.ListEmails(_35.Email, _35.ContactId, _35.Offset, _35.Limit), _35.Next, state, client) :
            op is InfusioOp<T>.CreateEmail _36 ? Exe(_36, () => client.CreateEmail(_36.EmailWithContent), _36.Next, state, client) :
            op is InfusioOp<T>.CreateEmails _37 ? Exe(_37, () => client.CreateEmails(_37.EmailWithContent), _37.Next, state, client) :
            op is InfusioOp<T>.DeleteEmails _38 ? Exe(_38, () => client.DeleteEmails(_38.EmailIds), _38.Next, state, client) :
            op is InfusioOp<T>.GetEmail _39 ? Exe(_39, () => client.GetEmail(_39.Id), _39.Next, state, client) :
            op is InfusioOp<T>.UpdateEmail _40 ? Exe(_40, () => client.UpdateEmail(_40.Id, _40.EmailWithContent), _40.Next, state, client) :
            op is InfusioOp<T>.DeleteEmail _41 ? Exe(_41, () => client.DeleteEmail(_41.Id), _41.Next, state, client) :
            op is InfusioOp<T>.ListFiles _42 ? Exe(_42, () => client.ListFiles(_42.Name, _42.Type, _42.Permission, _42.Viewable, _42.Offset, _42.Limit), _42.Next, state, client) :
            op is InfusioOp<T>.CreateFile _43 ? Exe(_43, () => client.CreateFile(_43.FileUpload), _43.Next, state, client) :
            op is InfusioOp<T>.GetFile _44 ? Exe(_44, () => client.GetFile(_44.FileId, _44.OptionalProperties), _44.Next, state, client) :
            op is InfusioOp<T>.UpdateFile _45 ? Exe(_45, () => client.UpdateFile(_45.FileId, _45.FileUpload), _45.Next, state, client) :
            op is InfusioOp<T>.DeleteFile _46 ? Exe(_46, () => client.DeleteFile(_46.FileId), _46.Next, state, client) :
            op is InfusioOp<T>.ListStoredHookSubscriptions _47 ? Exe(_47, () => client.ListStoredHookSubscriptions(), _47.Next, state, client) :
            op is InfusioOp<T>.CreateAHookSubscription _48 ? Exe(_48, () => client.CreateAHookSubscription(_48.RestHookRequest), _48.Next, state, client) :
            op is InfusioOp<T>.ListHookEventTypes _49 ? Exe(_49, () => client.ListHookEventTypes(), _49.Next, state, client) :
            op is InfusioOp<T>.RetrieveAHookSubscription _50 ? Exe(_50, () => client.RetrieveAHookSubscription(_50.Key), _50.Next, state, client) :
            op is InfusioOp<T>.UpdateAHookSubscription _51 ? Exe(_51, () => client.UpdateAHookSubscription(_51.RestHookRequest, _51.Key), _51.Next, state, client) :
            op is InfusioOp<T>.DeleteAHookSubscription _52 ? Exe(_52, () => client.DeleteAHookSubscription(_52.Key), _52.Next, state, client) :
            op is InfusioOp<T>.VerifyAHookSubscriptionDelayed _53 ? Exe(_53, () => client.VerifyAHookSubscriptionDelayed(_53.XHookSecret, _53.Key), _53.Next, state, client) :
            op is InfusioOp<T>.VerifyAHookSubscription _54 ? Exe(_54, () => client.VerifyAHookSubscription(_54.Key), _54.Next, state, client) :
            op is InfusioOp<T>.GetUserInfo _55 ? Exe(_55, () => client.GetUserInfo(), _55.Next, state, client) :
            op is InfusioOp<T>.ListOpportunities _56 ? Exe(_56, () => client.ListOpportunities(_56.Order, _56.SearchTerm, _56.StageId, _56.UserId, _56.Offset, _56.Limit), _56.Next, state, client) :
            op is InfusioOp<T>.CreateOpportunity _57 ? Exe(_57, () => client.CreateOpportunity(_57.Opportunity), _57.Next, state, client) :
            op is InfusioOp<T>.UpdateOpportunity _58 ? Exe(_58, () => client.UpdateOpportunity(_58.Opportunity), _58.Next, state, client) :
            op is InfusioOp<T>.RetrieveOpportunityModel _59 ? Exe(_59, () => client.RetrieveOpportunityModel(), _59.Next, state, client) :
            op is InfusioOp<T>.GetOpportunity _60 ? Exe(_60, () => client.GetOpportunity(_60.OpportunityId, _60.OptionalProperties), _60.Next, state, client) :
            op is InfusioOp<T>.UpdatePropertiesOnOpportunity _61 ? Exe(_61, () => client.UpdatePropertiesOnOpportunity(_61.OpportunityId, _61.Opportunity), _61.Next, state, client) :
            op is InfusioOp<T>.ListOpportunityStagePipelines _62 ? Exe(_62, () => client.ListOpportunityStagePipelines(), _62.Next, state, client) :
            op is InfusioOp<T>.ListOrders _63 ? Exe(_63, () => client.ListOrders(_63.ProductId, _63.ContactId, _63.Order, _63.Paid, _63.Offset, _63.Limit, _63.Until, _63.Since), _63.Next, state, client) :
            op is InfusioOp<T>.RetrieveOrderModel _64 ? Exe(_64, () => client.RetrieveOrderModel(), _64.Next, state, client) :
            op is InfusioOp<T>.GetOrder _65 ? Exe(_65, () => client.GetOrder(_65.OrderId), _65.Next, state, client) :
            op is InfusioOp<T>.ListTransactionsForOrder _66 ? Exe(_66, () => client.ListTransactionsForOrder(_66.OrderId, _66.ContactId, _66.Offset, _66.Limit, _66.Until, _66.Since), _66.Next, state, client) :
            op is InfusioOp<T>.ListProducts _67 ? Exe(_67, () => client.ListProducts(_67.Active, _67.Offset, _67.Limit), _67.Next, state, client) :
            op is InfusioOp<T>.ListProductsFromSyncToken _68 ? Exe(_68, () => client.ListProductsFromSyncToken(_68.Offset, _68.Limit, _68.SyncToken), _68.Next, state, client) :
            op is InfusioOp<T>.GetProduct _69 ? Exe(_69, () => client.GetProduct(_69.ProductId), _69.Next, state, client) :
            op is InfusioOp<T>.GetApplicationEnabled _70 ? Exe(_70, () => client.GetApplicationEnabled(), _70.Next, state, client) :
            op is InfusioOp<T>.GetContactOptionTypes _71 ? Exe(_71, () => client.GetContactOptionTypes(), _71.Next, state, client) :
            op is InfusioOp<T>.RetrieveSubscriptionModel _72 ? Exe(_72, () => client.RetrieveSubscriptionModel(), _72.Next, state, client) :
            op is InfusioOp<T>.ListTags _73 ? Exe(_73, () => client.ListTags(_73.Category, _73.Offset, _73.Limit), _73.Next, state, client) :
            op is InfusioOp<T>.CreateTag _74 ? Exe(_74, () => client.CreateTag(_74.Tag), _74.Next, state, client) :
            op is InfusioOp<T>.CreateTagCategory _75 ? Exe(_75, () => client.CreateTagCategory(_75.TagCategory), _75.Next, state, client) :
            op is InfusioOp<T>.GetTag _76 ? Exe(_76, () => client.GetTag(_76.Id), _76.Next, state, client) :
            op is InfusioOp<T>.ListContactsForTagId _77 ? Exe(_77, () => client.ListContactsForTagId(_77.TagId, _77.Offset, _77.Limit), _77.Next, state, client) :
            op is InfusioOp<T>.ApplyTagToContactIds _78 ? Exe(_78, () => client.ApplyTagToContactIds(_78.Ids, _78.TagId), _78.Next, state, client) :
            op is InfusioOp<T>.RemoveTagFromContactIds _79 ? Exe(_79, () => client.RemoveTagFromContactIds(_79.Ids, _79.TagId), _79.Next, state, client) :
            op is InfusioOp<T>.RemoveTagFromContactId _80 ? Exe(_80, () => client.RemoveTagFromContactId(_80.ContactId, _80.TagId), _80.Next, state, client) :
            op is InfusioOp<T>.ListTasks _81 ? Exe(_81, () => client.ListTasks(_81.Order, _81.Offset, _81.Limit, _81.Completed, _81.Until, _81.Since, _81.UserId, _81.HasDueDate, _81.ContactId), _81.Next, state, client) :
            op is InfusioOp<T>.CreateTask _82 ? Exe(_82, () => client.CreateTask(_82.Task), _82.Next, state, client) :
            op is InfusioOp<T>.RetrieveTaskModel _83 ? Exe(_83, () => client.RetrieveTaskModel(), _83.Next, state, client) :
            op is InfusioOp<T>.ListTasksForCurrentUser _84 ? Exe(_84, () => client.ListTasksForCurrentUser(_84.Order, _84.Offset, _84.Limit, _84.Completed, _84.Until, _84.Since, _84.UserId, _84.HasDueDate, _84.ContactId), _84.Next, state, client) :
            op is InfusioOp<T>.GetTask _85 ? Exe(_85, () => client.GetTask(_85.TaskId), _85.Next, state, client) :
            op is InfusioOp<T>.UpdateTask _86 ? Exe(_86, () => client.UpdateTask(_86.Task, _86.TaskId), _86.Next, state, client) :
            op is InfusioOp<T>.DeleteTask _87 ? Exe(_87, () => client.DeleteTask(_87.TaskId), _87.Next, state, client) :
            op is InfusioOp<T>.UpdatePropertiesOnTask _88 ? Exe(_88, () => client.UpdatePropertiesOnTask(_88.Task, _88.TaskId), _88.Next, state, client) :
            op is InfusioOp<T>.ListTransactions _89 ? Exe(_89, () => client.ListTransactions(_89.ContactId, _89.Offset, _89.Limit, _89.Until, _89.Since), _89.Next, state, client) :
            op is InfusioOp<T>.GetTransaction _90 ? Exe(_90, () => client.GetTransaction(_90.TransactionId), _90.Next, state, client) :
            throw new NotSupportedException();

        static EitherAsync<InfusioError, InfusioResult<B>> Exe<T, B>(Show<InfusioOp<T>> show, Func<Task<Either<InfusioError, T>>> fn, Func<T, InfusioOp<B>> nextOp, InfusioState state, InfusioClient client) =>
            from right in LogOperation(show, state, fn).ToAsync()
            from next in RunAsync(nextOp(right.Value), right.State, client)
            select next;

        static Task<Either<InfusioError, (InfusioState State, T Value)>> LogOperation<T>(Show<InfusioOp<T>> show, InfusioState state, Func<Task<Either<InfusioError, T>>> fn) =>
            from st in Right<InfusioError, (InfusioState, Unit)>((LogRequest(state, show), unit)).AsTask()
            from result in fn().ToAsync().Match(
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
    }

    public enum InfusioLogging
    {
        WithLogs,
        WithoutLogs
    }

    class InfusioState
    {
        public static InfusioState Create(InfusioLogging logging) => new InfusioState(Seq<string>(), logging == InfusioLogging.WithLogs ? true : false);
        public static InfusioState Create(Seq<string> logs, InfusioLogging logging) => new InfusioState(logs, logging == InfusioLogging.WithLogs ? true : false);
        public readonly Seq<string> Logs;
        public readonly bool UseLogging;

        InfusioState(Seq<string> logs = default, bool useLogging = default)
        {
            Logs = logs;
            UseLogging = useLogging;
        }

        public InfusioState Log(string message) =>
            new InfusioState(Logs.Append(Seq1(message)), UseLogging);
    }
}