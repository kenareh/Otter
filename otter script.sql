USE [Otter]
GO
SET IDENTITY_INSERT [Base].[Brands] ON 

INSERT [Base].[Brands] ([Id], [Name]) VALUES (1, N'asdad')
SET IDENTITY_INSERT [Base].[Brands] OFF
GO
SET IDENTITY_INSERT [Base].[Models] ON 

INSERT [Base].[Models] ([Id], [Name], [BrandId]) VALUES (1, N'asdasd', 1)
SET IDENTITY_INSERT [Base].[Models] OFF
GO
SET IDENTITY_INSERT [dbo].[SpeakerTestNumbers] ON 

INSERT [dbo].[SpeakerTestNumbers] ([Id], [FileName], [Number], [Order]) VALUES (1, N'9ee2de6e-b40d-43f2-962c-2333e59da962', 153, 58)
SET IDENTITY_INSERT [dbo].[SpeakerTestNumbers] OFF
GO
SET IDENTITY_INSERT [dbo].[Policies] ON 

INSERT [dbo].[Policies] ([Id], [Guid], [Price], [GuarantyStatus], [Mobile], [Otp], [OtpExpiredTime], [Imei], [Firstname], [Lastname], [NationalCode], [BirthDateString], [BirthDate], [Address], [PolicyState], [ModelId], [CityId], [IsMobileConfirmed], [SpeakerTestAttempt], [SpeakerTestNumberId], [SpeakerTestState], [BasePremium], [Discount], [DiscountCode], [FinalPremium], [PremiumRate], [MicrophoneTestState], [ScreenTestState]) VALUES (3, N'4df38c5a-0f83-4fb6-a44e-5d620f6548a6', 100000000, 0, N'09128668355', N'93551', CAST(N'2022-06-25T18:41:50.4458120' AS DateTime2), NULL, NULL, NULL, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 1, 1, NULL, 1, 3, 1, 1, 30000000, 0, N'', 30000000, 0.3, 0, 0)
INSERT [dbo].[Policies] ([Id], [Guid], [Price], [GuarantyStatus], [Mobile], [Otp], [OtpExpiredTime], [Imei], [Firstname], [Lastname], [NationalCode], [BirthDateString], [BirthDate], [Address], [PolicyState], [ModelId], [CityId], [IsMobileConfirmed], [SpeakerTestAttempt], [SpeakerTestNumberId], [SpeakerTestState], [BasePremium], [Discount], [DiscountCode], [FinalPremium], [PremiumRate], [MicrophoneTestState], [ScreenTestState]) VALUES (4, N'019282c5-79c1-46f7-b219-e2bb48639503', 100000000, 0, N'09128668355', N'23359', CAST(N'2022-06-25T18:49:13.4343816' AS DateTime2), NULL, NULL, NULL, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, 1, NULL, 0, 0, 1, 0, 30000000, 0, NULL, 30000000, 0.3, 0, 0)
SET IDENTITY_INSERT [dbo].[Policies] OFF
GO
SET IDENTITY_INSERT [dbo].[Configurations] ON 

INSERT [dbo].[Configurations] ([Id], [Key], [Value]) VALUES (1, N'PremiumRate', N'0.3')
INSERT [dbo].[Configurations] ([Id], [Key], [Value]) VALUES (2, N'IPGTerminalId', N'08069161')
INSERT [dbo].[Configurations] ([Id], [Key], [Value]) VALUES (3, N'IPGAcceptorId', N'992180008069161')
INSERT [dbo].[Configurations] ([Id], [Key], [Value]) VALUES (4, N'IPGPassPhrase', N'76FEB0F316883B83')
INSERT [dbo].[Configurations] ([Id], [Key], [Value]) VALUES (5, N'IPGAccountNumber', N'0000113939400')
INSERT [dbo].[Configurations] ([Id], [Key], [Value]) VALUES (6, N'IPGRsaPublicKey', N'-----BEGIN PUBLIC KEY-----
MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDfA/K5iF5s7GqNpBm+mRdZQvmA
mSMpO+65h4jrIEEbS+HoMGWVZsBz+Kmh7PUZX48bqSqIUcIOlF0glxLENGwCaQU2
lMrw1CNODqhEKbP4j2VjZisGgUSGv8fmBEpqBjwT1us6r+z0JwlCXeJ46BLAIyzg
003PX0iRNjhnzSOx7QIDAQAB
-----END PUBLIC KEY-----')
SET IDENTITY_INSERT [dbo].[Configurations] OFF
GO
SET IDENTITY_INSERT [dbo].[Discounts] ON 

INSERT [dbo].[Discounts] ([Id], [Code], [DiscountType], [AbsoluteDiscount], [PercentDiscount], [StartDate], [EndDate], [DiscountUsageType], [RemainingLimitedCount], [IsActive], [LimitedCount]) VALUES (3, N'123123', 0, NULL, 31, NULL, NULL, 0, 0, 1, NULL)
SET IDENTITY_INSERT [dbo].[Discounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Logs] ON 

INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (1, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T19:55:45.3370000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (2, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T19:55:47.3650000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (3, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T19:55:47.3950000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (4, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T19:55:47.4100000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (5, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T19:57:07.1980000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (6, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T19:57:08.8640000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (7, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T19:57:08.8890000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (8, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T19:57:08.9030000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (9, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T19:57:18.7990000' AS DateTime2), N'Error', N'An unhandled exception has occurred while executing the request.', N'Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware', N'Microsoft.AspNetCore.Diagnostics.DiagnosticsLoggerExtensions.UnhandledException', N'System.InvalidOperationException: Unable to resolve service for type ''Otter.Business.Definitions.Services.IPremiumInquiryService'' while attempting to activate ''Otter.HttpEndPoint.Controllers.PremiumInquiryController''.
   at Microsoft.Extensions.DependencyInjection.ActivatorUtilities.GetService(IServiceProvider sp, Type type, Type requiredBy, Boolean isDefaultParameterRequired)
   at lambda_method(Closure , IServiceProvider , Object[] )
   at Microsoft.AspNetCore.Mvc.Controllers.ControllerActivatorProvider.<>c__DisplayClass4_0.<CreateActivator>b__0(ControllerContext controllerContext)
   at Microsoft.AspNetCore.Mvc.Controllers.ControllerFactoryProvider.<>c__DisplayClass5_0.<CreateControllerFactory>g__CreateController|0(ControllerContext controllerContext)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()
--- End of stack trace from previous location where exception was thrown ---
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeNextResourceFilter>g__Awaited|24_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.Rethrow(ResourceExecutedContextSealed context)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.InvokeFilterPipelineAsync()
--- End of stack trace from previous location where exception was thrown ---
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Logged|17_1(ResourceInvoker invoker)
   at Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|6_0(Endpoint endpoint, Task requestTask, ILogger logger)
   at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (10, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T19:59:13.9950000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (11, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T19:59:15.0220000' AS DateTime2), N'Error', N'Stopped program because of exception', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'System.AggregateException: Some services are not able to be constructed (Error while validating the service descriptor ''ServiceType: Otter.DataAccess.IUnitOfWork Lifetime: Scoped ImplementationType: Otter.DataAccess.SQLServer.SqlUnitOfWork'': Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.) (Error while validating the service descriptor ''ServiceType: Otter.Business.Definitions.Services.ICurrencyService Lifetime: Scoped ImplementationType: Otter.Business.Implementations.Services.CurrencyService'': Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.) (Error while validating the service descriptor ''ServiceType: Otter.Business.Definitions.Services.IPolicyService Lifetime: Scoped ImplementationType: Otter.Business.Implementations.Services.PolicyService'': Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.) (Error while validating the service descriptor ''ServiceType: Otter.Business.Definitions.Services.IPremiumInquiryService Lifetime: Scoped ImplementationType: Otter.Business.Implementations.Services.PremiumInquiryService'': Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.) (Error while validating the service descriptor ''ServiceType: Otter.Business.Definitions.Services.IDiscountService Lifetime: Scoped ImplementationType: Otter.Business.Implementations.Services.DiscountService'': Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.) (Error while validating the service descriptor ''ServiceType: Otter.DataAccess.IUnitOfWork Lifetime: Scoped ImplementationType: Otter.DataAccess.SQLServer.SqlUnitOfWork'': Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.) (Error while validating the service descriptor ''ServiceType: Otter.Business.Definitions.Services.ICurrencyService Lifetime: Scoped ImplementationType: Otter.Business.Implementations.Services.CurrencyService'': Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.) (Error while validating the service descriptor ''ServiceType: Otter.Business.Definitions.Services.IPolicyService Lifetime: Scoped ImplementationType: Otter.Business.Implementations.Services.PolicyService'': Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.) (Error while validating the service descriptor ''ServiceType: Otter.Business.Definitions.Services.IPremiumInquiryService Lifetime: Scoped ImplementationType: Otter.Business.Implementations.Services.PremiumInquiryService'': Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.) (Error while validating the service descriptor ''ServiceType: Otter.Business.Definitions.Services.IDiscountService Lifetime: Scoped ImplementationType: Otter.Business.Implementations.Services.DiscountService'': Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.)
 ---> System.InvalidOperationException: Error while validating the service descriptor ''ServiceType: Otter.DataAccess.IUnitOfWork Lifetime: Scoped ImplementationType: Otter.DataAccess.SQLServer.SqlUnitOfWork'': Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.
 ---> System.InvalidOperationException: Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateArgumentCallSites(Type serviceType, Type implementationType, CallSiteChain callSiteChain, ParameterInfo[] parameters, Boolean throwIfCallSiteNotFound)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(ResultCache lifetime, Type serviceType, Type implementationType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(ServiceDescriptor descriptor, Type serviceType, CallSiteChain callSiteChain, Int32 slot)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.GetCallSite(ServiceDescriptor serviceDescriptor, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngine.ValidateService(ServiceDescriptor descriptor)
   --- End of inner exception stack trace ---
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngine.ValidateService(ServiceDescriptor descriptor)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider..ctor(IEnumerable`1 serviceDescriptors, IServiceProviderEngine engine, ServiceProviderOptions options)
   --- End of inner exception stack trace ---
 ---> (Inner Exception #1) System.InvalidOperationException: Error while validating the service descriptor ''ServiceType: Otter.Business.Definitions.Services.ICurrencyService Lifetime: Scoped ImplementationType: Otter.Business.Implementations.Services.CurrencyService'': Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.
 ---> System.InvalidOperationException: Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateArgumentCallSites(Type serviceType, Type implementationType, CallSiteChain callSiteChain, ParameterInfo[] parameters, Boolean throwIfCallSiteNotFound)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(ResultCache lifetime, Type serviceType, Type implementationType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(ServiceDescriptor descriptor, Type serviceType, CallSiteChain callSiteChain, Int32 slot)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(Type serviceType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateCallSite(Type serviceType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.<>c__DisplayClass7_0.<GetCallSite>b__0(Type type)
   at System.Collections.Concurrent.ConcurrentDictionary`2.GetOrAdd(TKey key, Func`2 valueFactory)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.GetCallSite(Type serviceType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateArgumentCallSites(Type serviceType, Type implementationType, CallSiteChain callSiteChain, ParameterInfo[] parameters, Boolean throwIfCallSiteNotFound)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(ResultCache lifetime, Type serviceType, Type implementationType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(ServiceDescriptor descriptor, Type serviceType, CallSiteChain callSiteChain, Int32 slot)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.GetCallSite(ServiceDescriptor serviceDescriptor, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngine.ValidateService(ServiceDescriptor descriptor)
   --- End of inner exception stack trace ---
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngine.ValidateService(ServiceDescriptor descriptor)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider..ctor(IEnumerable`1 serviceDescriptors, IServiceProviderEngine engine, ServiceProviderOptions options)<---

 ---> (Inner Exception #2) System.InvalidOperationException: Error while validating the service descriptor ''ServiceType: Otter.Business.Definitions.Services.IPolicyService Lifetime: Scoped ImplementationType: Otter.Business.Implementations.Services.PolicyService'': Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.
 ---> System.InvalidOperationException: Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateArgumentCallSites(Type serviceType, Type implementationType, CallSiteChain callSiteChain, ParameterInfo[] parameters, Boolean throwIfCallSiteNotFound)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(ResultCache lifetime, Type serviceType, Type implementationType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(ServiceDescriptor descriptor, Type serviceType, CallSiteChain callSiteChain, Int32 slot)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(Type serviceType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateCallSite(Type serviceType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.<>c__DisplayClass7_0.<GetCallSite>b__0(Type type)
   at System.Collections.Concurrent.ConcurrentDictionary`2.GetOrAdd(TKey key, Func`2 valueFactory)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.GetCallSite(Type serviceType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateArgumentCallSites(Type serviceType, Type implementationType, CallSiteChain callSiteChain, ParameterInfo[] parameters, Boolean throwIfCallSiteNotFound)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(ResultCache lifetime, Type serviceType, Type implementationType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(ServiceDescriptor descriptor, Type serviceType, CallSiteChain callSiteChain, Int32 slot)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.GetCallSite(ServiceDescriptor serviceDescriptor, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngine.ValidateService(ServiceDescriptor descriptor)
   --- End of inner exception stack trace ---
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngine.ValidateService(ServiceDescriptor descriptor)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider..ctor(IEnumerable`1 serviceDescriptors, IServiceProviderEngine engine, ServiceProviderOptions options)<---

 ---> (Inner Exception #3) System.InvalidOperationException: Error while validating the service descriptor ''ServiceType: Otter.Business.Definitions.Services.IPremiumInquiryService Lifetime: Scoped ImplementationType: Otter.Business.Implementations.Services.PremiumInquiryService'': Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.
 ---> System.InvalidOperationException: Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateArgumentCallSites(Type serviceType, Type implementationType, CallSiteChain callSiteChain, ParameterInfo[] parameters, Boolean throwIfCallSiteNotFound)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(ResultCache lifetime, Type serviceType, Type implementationType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(ServiceDescriptor descriptor, Type serviceType, CallSiteChain callSiteChain, Int32 slot)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(Type serviceType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateCallSite(Type serviceType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.<>c__DisplayClass7_0.<GetCallSite>b__0(Type type)
   at System.Collections.Concurrent.ConcurrentDictionary`2.GetOrAdd(TKey key, Func`2 valueFactory)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.GetCallSite(Type serviceType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateArgumentCallSites(Type serviceType, Type implementationType, CallSiteChain callSiteChain, ParameterInfo[] parameters, Boolean throwIfCallSiteNotFound)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(ResultCache lifetime, Type serviceType, Type implementationType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(ServiceDescriptor descriptor, Type serviceType, CallSiteChain callSiteChain, Int32 slot)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(Type serviceType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateCallSite(Type serviceType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.<>c__DisplayClass7_0.<GetCallSite>b__0(Type type)
   at System.Collections.Concurrent.ConcurrentDictionary`2.GetOrAdd(TKey key, Func`2 valueFactory)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.GetCallSite(Type serviceType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateArgumentCallSites(Type serviceType, Type implementationType, CallSiteChain callSiteChain, ParameterInfo[] parameters, Boolean throwIfCallSiteNotFound)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(ResultCache lifetime, Type serviceType, Type implementationType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(ServiceDescriptor descriptor, Type serviceType, CallSiteChain callSiteChain, Int32 slot)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.GetCallSite(ServiceDescriptor serviceDescriptor, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngine.ValidateService(ServiceDescriptor descriptor)
   --- End of inner exception stack trace ---
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngine.ValidateService(ServiceDescriptor descriptor)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider..ctor(IEnumerable`1 serviceDescriptors, IServiceProviderEngine engine, ServiceProviderOptions options)<---

 ---> (Inner Exception #4) System.InvalidOperationException: Error while validating the service descriptor ''ServiceType: Otter.Business.Definitions.Services.IDiscountService Lifetime: Scoped ImplementationType: Otter.Business.Implementations.Services.DiscountService'': Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.
 ---> System.InvalidOperationException: Unable to resolve service for type ''Otter.DataAccess.Repositories.IPolicyRepository'' while attempting to activate ''Otter.DataAccess.SQLServer.SqlUnitOfWork''.
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateArgumentCallSites(Type serviceType, Type implementationType, CallSiteChain callSiteChain, ParameterInfo[] parameters, Boolean throwIfCallSiteNotFound)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(ResultCache lifetime, Type serviceType, Type implementationType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(ServiceDescriptor descriptor, Type serviceType, CallSiteChain callSiteChain, Int32 slot)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(Type serviceType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateCallSite(Type serviceType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.<>c__DisplayClass7_0.<GetCallSite>b__0(Type type)
   at System.Collections.Concurrent.ConcurrentDictionary`2.GetOrAdd(TKey key, Func`2 valueFactory)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.GetCallSite(Type serviceType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateArgumentCallSites(Type serviceType, Type implementationType, CallSiteChain callSiteChain, ParameterInfo[] parameters, Boolean throwIfCallSiteNotFound)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(ResultCache lifetime, Type serviceType, Type implementationType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(ServiceDescriptor descriptor, Type serviceType, CallSiteChain callSiteChain, Int32 slot)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.GetCallSite(ServiceDescriptor serviceDescriptor, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngine.ValidateService(ServiceDescriptor descriptor)
   --- End of inner exception stack trace ---
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngine.ValidateService(ServiceDescriptor descriptor)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider..ctor(IEnumerable`1 serviceDescriptors, IServiceProviderEngine engine, ServiceProviderOptions options)<---
')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (12, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T20:00:59.6500000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (13, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T20:01:01.3240000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (14, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T20:01:01.3470000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (15, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T20:01:01.3640000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (16, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T20:01:38.3870000' AS DateTime2), N'Error', N'Failed executing DbCommand (57ms) [Parameters=[@__discountCode_0=''?'' (Size = 4000)], CommandType=''Text'', CommandTimeout=''30'']
SELECT TOP(1) [d].[Id], [d].[AbsoluteDiscount], [d].[Code], [d].[DiscountType], [d].[DiscountUsageType], [d].[EndDate], [d].[IsActive], [d].[LimitedCount], [d].[PercentDiscount], [d].[RemainingLimitedCount], [d].[StartDate]
FROM [Discounts] AS [d]
WHERE ((([d].[Code] = @__discountCode_0) AND ([d].[IsActive] = CAST(1 AS bit))) AND ([d].[StartDate] < GETDATE())) AND ([d].[EndDate] > GETDATE())', N'Microsoft.EntityFrameworkCore.Database.Command', N'Microsoft.EntityFrameworkCore.Diagnostics.EventDefinition`6.Log', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (17, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T20:01:38.4570000' AS DateTime2), N'Error', N'An exception occurred while iterating over the results of a query for context type ''Otter.DataAccess.SQLServer.ApplicationDbContext''.
Microsoft.Data.SqlClient.SqlException (0x80131904): Invalid column name ''LimitedCount''.
Invalid column name ''RemainingLimitedCount''.
   at Microsoft.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at Microsoft.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at Microsoft.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   at Microsoft.Data.SqlClient.SqlDataReader.get_MetaData()
   at Microsoft.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean isAsync, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   at System.Data.Common.DbCommand.ExecuteReader()
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.InitializeReader(DbContext _, Boolean result)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.MoveNext()
ClientConnectionId:855b4a53-a87d-4449-abc3-8c3dc763dc7a
Error Number:207,State:1,Class:16', N'Microsoft.EntityFrameworkCore.Query', N'Microsoft.EntityFrameworkCore.Diagnostics.EventDefinition`3.Log', N'Microsoft.Data.SqlClient.SqlException (0x80131904): Invalid column name ''LimitedCount''.
Invalid column name ''RemainingLimitedCount''.
   at Microsoft.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at Microsoft.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at Microsoft.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   at Microsoft.Data.SqlClient.SqlDataReader.get_MetaData()
   at Microsoft.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean isAsync, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   at System.Data.Common.DbCommand.ExecuteReader()
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.InitializeReader(DbContext _, Boolean result)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.MoveNext()
ClientConnectionId:855b4a53-a87d-4449-abc3-8c3dc763dc7a
Error Number:207,State:1,Class:16')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (18, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T20:04:41.9690000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (19, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T20:04:43.5000000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (20, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T20:04:43.5220000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (21, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T20:04:43.5350000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (22, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T20:11:15.3160000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (23, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T20:11:15.7000000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (24, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T20:11:15.7040000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (25, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-13T20:11:15.7040000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (26, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:04:28.2360000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (27, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:04:28.8350000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (28, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:04:28.8500000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (29, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:04:28.8530000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (30, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:05:31.5670000' AS DateTime2), N'Error', N'An unhandled exception has occurred while executing the request.', N'Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware', N'Microsoft.AspNetCore.Diagnostics.DiagnosticsLoggerExtensions.UnhandledException', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (31, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:05:31.6220000' AS DateTime2), N'Error', N'An exception was thrown attempting to display the error page.', N'Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware', N'Microsoft.AspNetCore.Diagnostics.DiagnosticsLoggerExtensions.DisplayErrorPageException', N'System.NullReferenceException: Object reference not set to an instance of an object.
   at Otter.Common.Exceptions.EntityNotFoundException.ToString() in F:\Workspace\Otter-BimeMobile\Otter.Common\Exceptions\EntityNotFoundException.cs:line 25
   at System.Exception.ToString()
   at System.AggregateException.ToString()
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.DisplayException(ErrorContext errorContext)
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (32, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:05:31.6220000' AS DateTime2), N'Error', N'Connection ID "18086456126605361758", Request ID "8000025f-0005-fb00-b63f-84710c7967bb": An unhandled exception was thrown by the application.', N'Microsoft.AspNetCore.Server.IIS.Core.IISHttpServer', N'Microsoft.AspNetCore.Server.IIS.Core.IISHttpContext+Log.ApplicationError', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (33, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:05:41.9120000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (34, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:05:44.4270000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (35, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:05:44.4310000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (36, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:05:44.4310000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (37, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:06:34.3650000' AS DateTime2), N'Error', N'An unhandled exception has occurred while executing the request.', N'Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware', N'Microsoft.AspNetCore.Diagnostics.DiagnosticsLoggerExtensions.UnhandledException', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (38, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:06:40.0930000' AS DateTime2), N'Error', N'An exception was thrown attempting to display the error page.', N'Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware', N'Microsoft.AspNetCore.Diagnostics.DiagnosticsLoggerExtensions.DisplayErrorPageException', N'System.NullReferenceException: Object reference not set to an instance of an object.
   at Otter.Common.Exceptions.EntityNotFoundException.ToString() in F:\Workspace\Otter-BimeMobile\Otter.Common\Exceptions\EntityNotFoundException.cs:line 25
   at System.Exception.ToString()
   at System.AggregateException.ToString()
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.DisplayException(ErrorContext errorContext)
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (39, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:06:40.1050000' AS DateTime2), N'Error', N'Connection ID "18374686511347007730", Request ID "800000f3-0007-ff00-b63f-84710c7967bb": An unhandled exception was thrown by the application.', N'Microsoft.AspNetCore.Server.IIS.Core.IISHttpServer', N'Microsoft.AspNetCore.Server.IIS.Core.IISHttpContext+Log.ApplicationError', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (40, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:07:20.9830000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (41, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:07:22.5660000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (42, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:07:22.5860000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (43, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:07:22.5980000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (44, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:09:31.1350000' AS DateTime2), N'Error', N'Failed executing DbCommand (17ms) [Parameters=[@p0=''?'' (Size = 500), @p1=''?'' (Size = 50) (DbType = DateTime2), @p2=''?'' (Size = 50), @p3=''?'' (DbType = Int64), @p4=''?'' (Size = 100), @p5=''?'' (DbType = Boolean), @p6=''?'' (DbType = Guid), @p7=''?'' (Size = 50), @p8=''?'' (DbType = Boolean), @p9=''?'' (Size = 100), @p10=''?'' (Size = 12), @p11=''?'' (DbType = Int64), @p12=''?'' (Size = 10), @p13=''?'' (Size = 6), @p14=''?'' (DbType = DateTime2), @p15=''?'' (DbType = Int32), @p16=''?'' (DbType = Int64), @p17=''?'' (DbType = Int32), @p18=''?'' (DbType = Int64), @p19=''?'' (DbType = Boolean)], CommandType=''Text'', CommandTimeout=''30'']
SET NOCOUNT ON;
INSERT INTO [Policies] ([Address], [BirthDate], [BirthDateString], [CityId], [Firstname], [GuarantyStatus], [Guid], [Imei], [IsMobileConfirmed], [Lastname], [Mobile], [ModelId], [NationalCode], [Otp], [OtpExpiredTime], [PolicyState], [Price], [SpeakerTestAttempt], [SpeakerTestNumberId], [SpeakerTestState])
VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16, @p17, @p18, @p19);
SELECT [Id]
FROM [Policies]
WHERE @@ROWCOUNT = 1 AND [Id] = scope_identity();', N'Microsoft.EntityFrameworkCore.Database.Command', N'Microsoft.EntityFrameworkCore.Diagnostics.EventDefinition`6.Log', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (45, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:09:31.2010000' AS DateTime2), N'Error', N'An exception occurred in the database while saving changes for context type ''Otter.DataAccess.SQLServer.ApplicationDbContext''.
Microsoft.EntityFrameworkCore.DbUpdateException: An error occurred while updating the entries. See the inner exception for details.
 ---> Microsoft.Data.SqlClient.SqlException (0x80131904): The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Policies_Cities_CityId". The conflict occurred in database "Otter", table "Base.Cities", column ''Id''.
The statement has been terminated.
   at Microsoft.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at Microsoft.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at Microsoft.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   at Microsoft.Data.SqlClient.SqlDataReader.get_MetaData()
   at Microsoft.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean isAsync, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   at System.Data.Common.DbCommand.ExecuteReader()
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
ClientConnectionId:d9e390d2-d677-414f-aa63-667666a6cf5c
Error Number:547,State:0,Class:16
   --- End of inner exception stack trace ---
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.Execute(IEnumerable`1 commandBatches, IRelationalConnection connection)
   at Microsoft.EntityFrameworkCore.Storage.RelationalDatabase.SaveChanges(IList`1 entries)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(IList`1 entriesToSave)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(DbContext _, Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.DbContext.SaveChanges(Boolean acceptAllChangesOnSuccess)', N'Microsoft.EntityFrameworkCore.Update', N'Microsoft.EntityFrameworkCore.Diagnostics.EventDefinition`3.Log', N'Microsoft.EntityFrameworkCore.DbUpdateException: An error occurred while updating the entries. See the inner exception for details.
 ---> Microsoft.Data.SqlClient.SqlException (0x80131904): The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Policies_Cities_CityId". The conflict occurred in database "Otter", table "Base.Cities", column ''Id''.
The statement has been terminated.
   at Microsoft.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at Microsoft.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at Microsoft.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   at Microsoft.Data.SqlClient.SqlDataReader.get_MetaData()
   at Microsoft.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean isAsync, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   at System.Data.Common.DbCommand.ExecuteReader()
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
ClientConnectionId:d9e390d2-d677-414f-aa63-667666a6cf5c
Error Number:547,State:0,Class:16
   --- End of inner exception stack trace ---
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.Execute(IEnumerable`1 commandBatches, IRelationalConnection connection)
   at Microsoft.EntityFrameworkCore.Storage.RelationalDatabase.SaveChanges(IList`1 entries)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(IList`1 entriesToSave)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(DbContext _, Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.DbContext.SaveChanges(Boolean acceptAllChangesOnSuccess)')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (46, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:12:09.4220000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (47, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:28:36.3660000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (48, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:28:37.5930000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (49, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:28:37.6140000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (50, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:28:37.6260000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (51, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:28:43.8910000' AS DateTime2), N'Error', N'Unable to cast object of type ''Otter.Common.Entities.Configuration'' to type ''System.IConvertible''.', N'Otter.HttpEndPoint.Controllers.PolicyController', N'Otter.HttpEndPoint.Controllers.PolicyController.PostBasicInformation', N'System.InvalidCastException: Unable to cast object of type ''Otter.Common.Entities.Configuration'' to type ''System.IConvertible''.
   at System.Convert.ToDouble(Object value)
   at Otter.Business.Implementations.Services.ConfigurationService.GetPremiumRate() in F:\Workspace\Otter-BimeMobile\Otter.Business\Implementations\Services\ConfigurationService.cs:line 26
   at Otter.Business.Implementations.Services.PremiumInquiryService.PremiumInquiry(InquiryRequestDto dto, Boolean isActualUseForPolicy) in F:\Workspace\Otter-BimeMobile\Otter.Business\Implementations\Services\PremiumInquiryService.cs:line 20
   at Otter.Business.Implementations.Services.PolicyService.InsertBasicInformation(BasicInformationRequestDto dto) in F:\Workspace\Otter-BimeMobile\Otter.Business\Implementations\Services\PolicyService.cs:line 45
   at Otter.HttpEndPoint.Controllers.PolicyController.PostBasicInformation(BasicInformationRequestDto dto) in F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint\Controllers\PolicyController.cs:line 56')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (52, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:31:25.2120000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (53, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:31:26.7430000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (54, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:31:26.7640000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (55, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:31:26.7770000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (56, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:31:47.4810000' AS DateTime2), N'Error', N'Unable to cast object of type ''Otter.Common.Entities.Configuration'' to type ''System.IConvertible''.', N'Otter.HttpEndPoint.Controllers.PolicyController', N'Otter.HttpEndPoint.Controllers.PolicyController.PostBasicInformation', N'System.InvalidCastException: Unable to cast object of type ''Otter.Common.Entities.Configuration'' to type ''System.IConvertible''.
   at System.Convert.ToDouble(Object value)
   at Otter.Business.Implementations.Services.ConfigurationService.GetPremiumRate() in F:\Workspace\Otter-BimeMobile\Otter.Business\Implementations\Services\ConfigurationService.cs:line 26
   at Otter.Business.Implementations.Services.PremiumInquiryService.PremiumInquiry(InquiryRequestDto dto, Boolean isActualUseForPolicy) in F:\Workspace\Otter-BimeMobile\Otter.Business\Implementations\Services\PremiumInquiryService.cs:line 21
   at Otter.Business.Implementations.Services.PolicyService.InsertBasicInformation(BasicInformationRequestDto dto) in F:\Workspace\Otter-BimeMobile\Otter.Business\Implementations\Services\PolicyService.cs:line 45
   at Otter.HttpEndPoint.Controllers.PolicyController.PostBasicInformation(BasicInformationRequestDto dto) in F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint\Controllers\PolicyController.cs:line 56')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (57, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:32:12.7700000' AS DateTime2), N'Error', N'Unable to cast object of type ''Otter.Common.Entities.Configuration'' to type ''System.IConvertible''.', N'Otter.HttpEndPoint.Controllers.PolicyController', N'Otter.HttpEndPoint.Controllers.PolicyController.PostBasicInformation', N'System.InvalidCastException: Unable to cast object of type ''Otter.Common.Entities.Configuration'' to type ''System.IConvertible''.
   at System.Convert.ToDouble(Object value)
   at Otter.Business.Implementations.Services.ConfigurationService.GetPremiumRate() in F:\Workspace\Otter-BimeMobile\Otter.Business\Implementations\Services\ConfigurationService.cs:line 26
   at Otter.Business.Implementations.Services.PremiumInquiryService.PremiumInquiry(InquiryRequestDto dto, Boolean isActualUseForPolicy) in F:\Workspace\Otter-BimeMobile\Otter.Business\Implementations\Services\PremiumInquiryService.cs:line 21
   at Otter.Business.Implementations.Services.PolicyService.InsertBasicInformation(BasicInformationRequestDto dto) in F:\Workspace\Otter-BimeMobile\Otter.Business\Implementations\Services\PolicyService.cs:line 45
   at Otter.HttpEndPoint.Controllers.PolicyController.PostBasicInformation(BasicInformationRequestDto dto) in F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint\Controllers\PolicyController.cs:line 56')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (58, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:34:10.4730000' AS DateTime2), N'Error', N'Failed executing DbCommand (5ms) [Parameters=[@p0=''?'' (Size = 500), @p1=''?'' (DbType = Int64), @p2=''?'' (Size = 50) (DbType = DateTime2), @p3=''?'' (Size = 50), @p4=''?'' (DbType = Int64), @p5=''?'' (DbType = Int64), @p6=''?'' (Size = 4000), @p7=''?'' (DbType = Int64), @p8=''?'' (Size = 100), @p9=''?'' (DbType = Boolean), @p10=''?'' (DbType = Guid), @p11=''?'' (Size = 50), @p12=''?'' (DbType = Boolean), @p13=''?'' (Size = 100), @p14=''?'' (Size = 12), @p15=''?'' (DbType = Int64), @p16=''?'' (Size = 10), @p17=''?'' (Size = 6), @p18=''?'' (DbType = DateTime2), @p19=''?'' (DbType = Int32), @p20=''?'' (DbType = Double), @p21=''?'' (DbType = Int64), @p22=''?'' (DbType = Int32), @p23=''?'' (DbType = Int64), @p24=''?'' (DbType = Boolean)], CommandType=''Text'', CommandTimeout=''30'']
SET NOCOUNT ON;
INSERT INTO [Policies] ([Address], [BasePremium], [BirthDate], [BirthDateString], [CityId], [Discount], [DiscountCode], [FinalPremium], [Firstname], [GuarantyStatus], [Guid], [Imei], [IsMobileConfirmed], [Lastname], [Mobile], [ModelId], [NationalCode], [Otp], [OtpExpiredTime], [PolicyState], [PremiumRate], [Price], [SpeakerTestAttempt], [SpeakerTestNumberId], [SpeakerTestState])
VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16, @p17, @p18, @p19, @p20, @p21, @p22, @p23, @p24);
SELECT [Id]
FROM [Policies]
WHERE @@ROWCOUNT = 1 AND [Id] = scope_identity();', N'Microsoft.EntityFrameworkCore.Database.Command', N'Microsoft.EntityFrameworkCore.Diagnostics.EventDefinition`6.Log', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (59, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:34:10.5240000' AS DateTime2), N'Error', N'An exception occurred in the database while saving changes for context type ''Otter.DataAccess.SQLServer.ApplicationDbContext''.
Microsoft.EntityFrameworkCore.DbUpdateException: An error occurred while updating the entries. See the inner exception for details.
 ---> Microsoft.Data.SqlClient.SqlException (0x80131904): Invalid column name ''BasePremium''.
Invalid column name ''Discount''.
Invalid column name ''DiscountCode''.
Invalid column name ''FinalPremium''.
Invalid column name ''PremiumRate''.
   at Microsoft.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at Microsoft.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at Microsoft.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   at Microsoft.Data.SqlClient.SqlDataReader.get_MetaData()
   at Microsoft.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean isAsync, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   at System.Data.Common.DbCommand.ExecuteReader()
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
ClientConnectionId:ad107881-c7a6-4fa5-a3d3-1e1f2d2b6f98
Error Number:207,State:1,Class:16
   --- End of inner exception stack trace ---
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.Execute(IEnumerable`1 commandBatches, IRelationalConnection connection)
   at Microsoft.EntityFrameworkCore.Storage.RelationalDatabase.SaveChanges(IList`1 entries)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(IList`1 entriesToSave)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(DbContext _, Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.DbContext.SaveChanges(Boolean acceptAllChangesOnSuccess)', N'Microsoft.EntityFrameworkCore.Update', N'Microsoft.EntityFrameworkCore.Diagnostics.EventDefinition`3.Log', N'Microsoft.EntityFrameworkCore.DbUpdateException: An error occurred while updating the entries. See the inner exception for details.
 ---> Microsoft.Data.SqlClient.SqlException (0x80131904): Invalid column name ''BasePremium''.
Invalid column name ''Discount''.
Invalid column name ''DiscountCode''.
Invalid column name ''FinalPremium''.
Invalid column name ''PremiumRate''.
   at Microsoft.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at Microsoft.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at Microsoft.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   at Microsoft.Data.SqlClient.SqlDataReader.get_MetaData()
   at Microsoft.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean isAsync, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   at System.Data.Common.DbCommand.ExecuteReader()
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
ClientConnectionId:ad107881-c7a6-4fa5-a3d3-1e1f2d2b6f98
Error Number:207,State:1,Class:16
   --- End of inner exception stack trace ---
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.Execute(IEnumerable`1 commandBatches, IRelationalConnection connection)
   at Microsoft.EntityFrameworkCore.Storage.RelationalDatabase.SaveChanges(IList`1 entries)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(IList`1 entriesToSave)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(DbContext _, Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.DbContext.SaveChanges(Boolean acceptAllChangesOnSuccess)')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (60, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:35:15.2400000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (61, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:35:16.7920000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (62, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:35:16.8120000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (63, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:35:16.8240000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (64, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:35:38.4060000' AS DateTime2), N'Error', N'Failed executing DbCommand (8ms) [Parameters=[@p0=''?'' (Size = 500), @p1=''?'' (DbType = Int64), @p2=''?'' (Size = 50) (DbType = DateTime2), @p3=''?'' (Size = 50), @p4=''?'' (DbType = Int64), @p5=''?'' (DbType = Int64), @p6=''?'' (Size = 4000), @p7=''?'' (DbType = Int64), @p8=''?'' (Size = 100), @p9=''?'' (DbType = Boolean), @p10=''?'' (DbType = Guid), @p11=''?'' (Size = 50), @p12=''?'' (DbType = Boolean), @p13=''?'' (Size = 100), @p14=''?'' (Size = 12), @p15=''?'' (DbType = Int64), @p16=''?'' (Size = 10), @p17=''?'' (Size = 6), @p18=''?'' (DbType = DateTime2), @p19=''?'' (DbType = Int32), @p20=''?'' (DbType = Double), @p21=''?'' (DbType = Int64), @p22=''?'' (DbType = Int32), @p23=''?'' (DbType = Int64), @p24=''?'' (DbType = Boolean)], CommandType=''Text'', CommandTimeout=''30'']
SET NOCOUNT ON;
INSERT INTO [Policies] ([Address], [BasePremium], [BirthDate], [BirthDateString], [CityId], [Discount], [DiscountCode], [FinalPremium], [Firstname], [GuarantyStatus], [Guid], [Imei], [IsMobileConfirmed], [Lastname], [Mobile], [ModelId], [NationalCode], [Otp], [OtpExpiredTime], [PolicyState], [PremiumRate], [Price], [SpeakerTestAttempt], [SpeakerTestNumberId], [SpeakerTestState])
VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16, @p17, @p18, @p19, @p20, @p21, @p22, @p23, @p24);
SELECT [Id]
FROM [Policies]
WHERE @@ROWCOUNT = 1 AND [Id] = scope_identity();', N'Microsoft.EntityFrameworkCore.Database.Command', N'Microsoft.EntityFrameworkCore.Diagnostics.EventDefinition`6.Log', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (65, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:35:38.4690000' AS DateTime2), N'Error', N'An exception occurred in the database while saving changes for context type ''Otter.DataAccess.SQLServer.ApplicationDbContext''.
Microsoft.EntityFrameworkCore.DbUpdateException: An error occurred while updating the entries. See the inner exception for details.
 ---> Microsoft.Data.SqlClient.SqlException (0x80131904): The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Policies_Models_ModelId". The conflict occurred in database "Otter", table "Base.Models", column ''Id''.
The statement has been terminated.
   at Microsoft.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at Microsoft.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at Microsoft.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   at Microsoft.Data.SqlClient.SqlDataReader.get_MetaData()
   at Microsoft.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean isAsync, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   at System.Data.Common.DbCommand.ExecuteReader()
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
ClientConnectionId:b680152d-e925-415b-bdf2-c6793b50f348
Error Number:547,State:0,Class:16
   --- End of inner exception stack trace ---
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.Execute(IEnumerable`1 commandBatches, IRelationalConnection connection)
   at Microsoft.EntityFrameworkCore.Storage.RelationalDatabase.SaveChanges(IList`1 entries)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(IList`1 entriesToSave)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(DbContext _, Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.DbContext.SaveChanges(Boolean acceptAllChangesOnSuccess)', N'Microsoft.EntityFrameworkCore.Update', N'Microsoft.EntityFrameworkCore.Diagnostics.EventDefinition`3.Log', N'Microsoft.EntityFrameworkCore.DbUpdateException: An error occurred while updating the entries. See the inner exception for details.
 ---> Microsoft.Data.SqlClient.SqlException (0x80131904): The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Policies_Models_ModelId". The conflict occurred in database "Otter", table "Base.Models", column ''Id''.
The statement has been terminated.
   at Microsoft.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at Microsoft.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at Microsoft.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   at Microsoft.Data.SqlClient.SqlDataReader.get_MetaData()
   at Microsoft.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean isAsync, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   at System.Data.Common.DbCommand.ExecuteReader()
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
ClientConnectionId:b680152d-e925-415b-bdf2-c6793b50f348
Error Number:547,State:0,Class:16
   --- End of inner exception stack trace ---
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.Execute(IEnumerable`1 commandBatches, IRelationalConnection connection)
   at Microsoft.EntityFrameworkCore.Storage.RelationalDatabase.SaveChanges(IList`1 entries)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(IList`1 entriesToSave)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(DbContext _, Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.DbContext.SaveChanges(Boolean acceptAllChangesOnSuccess)')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (66, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:36:45.2710000' AS DateTime2), N'Error', N'An error occurred while updating the entries. See the inner exception for details.', N'Otter.HttpEndPoint.Controllers.PolicyController', N'Otter.HttpEndPoint.Controllers.PolicyController.PostBasicInformation', N'Otter.DataAccess.Exceptions.DatabaseException: An error occurred while updating the entries. See the inner exception for details.
 ---> Microsoft.EntityFrameworkCore.DbUpdateException: An error occurred while updating the entries. See the inner exception for details.
 ---> Microsoft.Data.SqlClient.SqlException (0x80131904): The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Policies_Models_ModelId". The conflict occurred in database "Otter", table "Base.Models", column ''Id''.
The statement has been terminated.
   at Microsoft.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at Microsoft.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at Microsoft.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   at Microsoft.Data.SqlClient.SqlDataReader.get_MetaData()
   at Microsoft.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean isAsync, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   at System.Data.Common.DbCommand.ExecuteReader()
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
ClientConnectionId:b680152d-e925-415b-bdf2-c6793b50f348
Error Number:547,State:0,Class:16
   --- End of inner exception stack trace ---
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.Execute(IEnumerable`1 commandBatches, IRelationalConnection connection)
   at Microsoft.EntityFrameworkCore.Storage.RelationalDatabase.SaveChanges(IList`1 entries)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(IList`1 entriesToSave)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(DbContext _, Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.DbContext.SaveChanges(Boolean acceptAllChangesOnSuccess)
   at Otter.DataAccess.SQLServer.ApplicationDbContext.SaveChanges(Boolean acceptAllChangesOnSuccess) in F:\Workspace\Otter-BimeMobile\Otter.DataAccess.SQLServer\ApplicationDbContext.cs:line 47
   at Microsoft.EntityFrameworkCore.DbContext.SaveChanges()
   at Otter.DataAccess.SQLServer.ApplicationDbContext.SaveChanges() in F:\Workspace\Otter-BimeMobile\Otter.DataAccess.SQLServer\ApplicationDbContext.cs:line 41
   at Otter.DataAccess.SQLServer.SqlUnitOfWork.Commit() in F:\Workspace\Otter-BimeMobile\Otter.DataAccess.SQLServer\SqlUnitOfWork.cs:line 43
   --- End of inner exception stack trace ---
   at Otter.DataAccess.SQLServer.SqlUnitOfWork.Commit() in F:\Workspace\Otter-BimeMobile\Otter.DataAccess.SQLServer\SqlUnitOfWork.cs:line 47
   at Otter.Business.Implementations.Services.PolicyService.InsertBasicInformation(BasicInformationRequestDto dto) in F:\Workspace\Otter-BimeMobile\Otter.Business\Implementations\Services\PolicyService.cs:line 67
   at Otter.HttpEndPoint.Controllers.PolicyController.PostBasicInformation(BasicInformationRequestDto dto) in F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint\Controllers\PolicyController.cs:line 56')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (67, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:37:22.4820000' AS DateTime2), N'Error', N'An invalid request URI was provided. The request URI must either be an absolute URI or BaseAddress must be set.', N'Otter.ExternalService.Utilities.InternalClientService', N'Otter.ExternalService.Utilities.InternalClientService.PostAsync', N'System.InvalidOperationException: An invalid request URI was provided. The request URI must either be an absolute URI or BaseAddress must be set.
   at System.Net.Http.HttpClient.PrepareRequestMessage(HttpRequestMessage request)
   at System.Net.Http.HttpClient.SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
   at System.Net.Http.HttpClient.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
   at System.Net.Http.HttpClient.PostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
   at System.Net.Http.HttpClient.PostAsync(String requestUri, HttpContent content)
   at Otter.ExternalService.Utilities.InternalClientService.PostAsync(String path, Object data) in F:\Workspace\Otter-BimeMobile\Otter.ExternalService\Utilities\IInternalClientService.cs:line 148')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (68, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:37:22.6480000' AS DateTime2), N'Error', N'کد تایید ارسال نشد 09128668355 : 93551', N'Otter.Business.Implementations.Services.PolicyService', N'Otter.Business.Implementations.Services.PolicyService.InsertBasicInformation', N'Can not to integrate to .')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (69, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:43:11.7120000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (70, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:43:12.0880000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (71, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:43:12.0880000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (72, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:43:12.0880000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (73, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:44:13.6210000' AS DateTime2), N'Error', N'An invalid request URI was provided. The request URI must either be an absolute URI or BaseAddress must be set.', N'Otter.ExternalService.Utilities.InternalClientService', N'Otter.ExternalService.Utilities.InternalClientService.PostAsync', N'System.InvalidOperationException: An invalid request URI was provided. The request URI must either be an absolute URI or BaseAddress must be set.
   at System.Net.Http.HttpClient.PrepareRequestMessage(HttpRequestMessage request)
   at System.Net.Http.HttpClient.SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
   at System.Net.Http.HttpClient.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
   at System.Net.Http.HttpClient.PostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
   at System.Net.Http.HttpClient.PostAsync(String requestUri, HttpContent content)
   at Otter.ExternalService.Utilities.InternalClientService.PostAsync(String path, Object data) in F:\Workspace\Otter-BimeMobile\Otter.ExternalService\Utilities\IInternalClientService.cs:line 148')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (74, N'Sample', N'TEJARATINS-0610', CAST(N'2022-06-25T18:44:13.6210000' AS DateTime2), N'Error', N'کد تایید ارسال نشد 09128668355 : 23359', N'Otter.Business.Implementations.Services.PolicyService', N'Otter.Business.Implementations.Services.PolicyService.InsertBasicInformation', N'Can not to integrate to .')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (75, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:03:59.6420000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (76, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:04:02.2870000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (77, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:04:02.2940000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (78, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:04:02.2940000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (79, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:04:11.2590000' AS DateTime2), N'Error', N'An unhandled exception has occurred while executing the request.', N'Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware', N'Microsoft.AspNetCore.Diagnostics.DiagnosticsLoggerExtensions.UnhandledException', N'System.InvalidOperationException: Unable to resolve service for type ''Otter.Business.Definitions.Services.IBaseDataService'' while attempting to activate ''Otter.HttpEndPoint.Controllers.BaseDataController''.
   at Microsoft.Extensions.DependencyInjection.ActivatorUtilities.GetService(IServiceProvider sp, Type type, Type requiredBy, Boolean isDefaultParameterRequired)
   at lambda_method(Closure , IServiceProvider , Object[] )
   at Microsoft.AspNetCore.Mvc.Controllers.ControllerActivatorProvider.<>c__DisplayClass4_0.<CreateActivator>b__0(ControllerContext controllerContext)
   at Microsoft.AspNetCore.Mvc.Controllers.ControllerFactoryProvider.<>c__DisplayClass5_0.<CreateControllerFactory>g__CreateController|0(ControllerContext controllerContext)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()
--- End of stack trace from previous location where exception was thrown ---
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeNextResourceFilter>g__Awaited|24_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.Rethrow(ResourceExecutedContextSealed context)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.InvokeFilterPipelineAsync()
--- End of stack trace from previous location where exception was thrown ---
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
   at Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|6_0(Endpoint endpoint, Task requestTask, ILogger logger)
   at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (80, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:04:30.9190000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (81, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:04:31.4990000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (82, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:04:31.5080000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (83, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:04:31.5080000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (84, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:07:09.6790000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (85, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:07:10.0940000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (86, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:07:10.0940000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (87, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:07:10.1010000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (88, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:11:03.8940000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (89, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:11:06.5090000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (90, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:11:06.5090000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (91, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:11:06.5090000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (92, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:12:45.0730000' AS DateTime2), N'Error', N'An invalid request URI was provided. The request URI must either be an absolute URI or BaseAddress must be set.', N'Otter.ExternalService.Utilities.InternalClientService', N'Otter.ExternalService.Utilities.InternalClientService.PostAsync', N'System.InvalidOperationException: An invalid request URI was provided. The request URI must either be an absolute URI or BaseAddress must be set.
   at System.Net.Http.HttpClient.PrepareRequestMessage(HttpRequestMessage request)
   at System.Net.Http.HttpClient.SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
   at System.Net.Http.HttpClient.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
   at System.Net.Http.HttpClient.PostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
   at System.Net.Http.HttpClient.PostAsync(String requestUri, HttpContent content)
   at Otter.ExternalService.Utilities.InternalClientService.PostAsync(String path, Object data) in F:\Workspace\Otter-BimeMobile\Otter.ExternalService\Utilities\IInternalClientService.cs:line 148')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (93, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:12:45.2390000' AS DateTime2), N'Error', N'کد تایید ارسال نشد 09128668355 : 27882', N'Otter.Business.Implementations.Services.PolicyService', N'Otter.Business.Implementations.Services.PolicyService.InsertBasicInformation', N'Can not to integrate to .')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (94, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:23:50.1840000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (95, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:23:51.7080000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (96, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:23:51.7330000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (97, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:23:51.7540000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (98, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:56:51.4710000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (99, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:56:51.9020000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
GO
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (100, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:56:51.9020000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (101, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T17:56:51.9020000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (102, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:01:12.0260000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (103, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:01:12.5730000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (104, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:01:12.5730000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (105, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:01:12.5730000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (106, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:01:35.3230000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (107, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:01:35.7300000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (108, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:01:35.7300000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (109, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:01:35.7300000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (110, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:02:02.1050000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (111, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:02:03.8650000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (112, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:02:03.8650000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (113, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:02:03.8650000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (114, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:02:21.5030000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (115, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:02:23.1660000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (116, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:02:23.1850000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (117, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:02:23.1960000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (118, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:14:17.1730000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (119, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:14:17.6310000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (120, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:14:17.6310000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (121, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:14:17.6400000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (122, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:14:34.1100000' AS DateTime2), N'Error', N'An unhandled exception has occurred while executing the request.', N'Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware', N'Microsoft.AspNetCore.Diagnostics.DiagnosticsLoggerExtensions.UnhandledException', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (123, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:14:34.1320000' AS DateTime2), N'Error', N'An exception was thrown attempting to display the error page.', N'Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware', N'Microsoft.AspNetCore.Diagnostics.DiagnosticsLoggerExtensions.DisplayErrorPageException', N'System.NullReferenceException: Object reference not set to an instance of an object.
   at Otter.Common.Exceptions.EntityNotFoundException.ToString() in F:\Workspace\Otter-BimeMobile\Otter.Common\Exceptions\EntityNotFoundException.cs:line 25
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.DisplayException(ErrorContext errorContext)
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (124, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:14:34.1320000' AS DateTime2), N'Error', N'Connection ID "18374686507052040259", Request ID "80000044-0006-ff00-b63f-84710c7967bb": An unhandled exception was thrown by the application.', N'Microsoft.AspNetCore.Server.IIS.Core.IISHttpServer', N'Microsoft.AspNetCore.Server.IIS.Core.IISHttpContext+Log.ApplicationError', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (125, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:14:46.5130000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (126, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:14:48.0870000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (127, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:14:48.1070000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (128, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:14:48.1200000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (129, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:15:44.5890000' AS DateTime2), N'Error', N'An unhandled exception has occurred while executing the request.', N'Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware', N'Microsoft.AspNetCore.Diagnostics.DiagnosticsLoggerExtensions.UnhandledException', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (130, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:16:48.1950000' AS DateTime2), N'Debug', N'init main', N'Otter.HttpEndPoint.Program', N'Otter.HttpEndPoint.Program.Main', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (131, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:16:48.6320000' AS DateTime2), N'Info', N'Application started. Press Ctrl+C to shut down.', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (132, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:16:48.6420000' AS DateTime2), N'Info', N'Hosting environment: Development', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (133, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:16:48.6420000' AS DateTime2), N'Info', N'Content root path: F:\Workspace\Otter-BimeMobile\Otter.HttpEndPoint', N'Microsoft.Hosting.Lifetime', N'Microsoft.Extensions.Hosting.Internal.ConsoleLifetime.OnApplicationStarted', N'')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (134, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:19:28.4290000' AS DateTime2), N'Error', N'No connection could be made because the target machine actively refused it.', N'Otter.ExternalService.Utilities.InternalClientService', N'Otter.ExternalService.Utilities.InternalClientService.PostAsync', N'System.Net.Http.HttpRequestException: No connection could be made because the target machine actively refused it.
 ---> System.Net.Sockets.SocketException (10061): No connection could be made because the target machine actively refused it.
   at System.Net.Http.ConnectHelper.ConnectAsync(String host, Int32 port, CancellationToken cancellationToken)
   --- End of inner exception stack trace ---
   at System.Net.Http.ConnectHelper.ConnectAsync(String host, Int32 port, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.ConnectAsync(HttpRequestMessage request, Boolean allowHttp2, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.CreateHttp11ConnectionAsync(HttpRequestMessage request, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.GetHttpConnectionAsync(HttpRequestMessage request, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.SendWithRetryAsync(HttpRequestMessage request, Boolean doRequestAuth, CancellationToken cancellationToken)
   at System.Net.Http.RedirectHandler.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
   at System.Net.Http.DiagnosticsHandler.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
   at System.Net.Http.HttpClient.FinishSendAsyncBuffered(Task`1 sendTask, HttpRequestMessage request, CancellationTokenSource cts, Boolean disposeCts)
   at Otter.ExternalService.Utilities.InternalClientService.PostAsync(String path, Object data) in F:\Workspace\Otter-BimeMobile\Otter.ExternalService\Utilities\IInternalClientService.cs:line 148')
INSERT [dbo].[Logs] ([Id], [Application], [MachineName], [Logged], [Level], [Message], [Logger], [Callsite], [Exception]) VALUES (135, N'Sample', N'TEJARATINS-0610', CAST(N'2022-07-02T18:19:28.4780000' AS DateTime2), N'Error', N'کد تایید ارسال نشد 09128668355 : 64367', N'Otter.Business.Implementations.Services.PolicyService', N'Otter.Business.Implementations.Services.PolicyService.InsertBasicInformation', N'Can not to integrate to .')
SET IDENTITY_INSERT [dbo].[Logs] OFF
GO
