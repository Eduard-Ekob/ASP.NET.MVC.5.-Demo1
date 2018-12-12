using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

//C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Config\web.config

namespace ASP.NET_Http_Pipline
{
    public class MvcApplication : System.Web.HttpApplication

    //https://github.com/Microsoft/referencesource/blob/master/System.Web/HttpApplication.cs
    {
        public MvcApplication()
        {
            //BeginRequest += MvcApplication_BeginRequest;
            //AuthenticateRequest += MvcApplication_AuthenticateRequest;
            //PreRequestHandlerExecute += (sender, args) => this.Response.Write("<h2>Application_PreRequestHandlerExecute</h2>");
            //EndRequest += (sender, args) => this.Response.Write("<h2>Application_EndRequest</h2>");
        }

        private void MvcApplication_AuthenticateRequest(object sender, EventArgs e)
        {
            this.Response.Write("<h2>Application_AuthenticateRequest</h2>");
        }

        private void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            this.Response.Write("<h2>Application_BeginRequest</h2>");
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

#region События приложения ASP.NET
//Жизненный цикл приложения предполагает вызов ряда событий в
//следующей последовательности:

// - BeginRequest: событие возникает, когда приложение получает новый запрос

// - AuthenticateRequest/PostAuthenticateRequest: событие AuthenticateRequest 
//возникает при идентификации(аутентификации) пользователя, сделавшего запрос.
//А после его обработки срабатывает событие PostAuthenticateRequest

// - AuthorizeRequest/PostAuthorizeRequest: AuthorizeRequest возникает при 
//авторизации запроса, после этого срабатывает событие PostAuthorizeRequest

// - ResolveRequestCache/PostResolveRequestCache: событие ResolveRequestCache возникает, 
//когда приложение обращается к кэшу для получения данных. 
//При получении данных их кэша срабатывает событие PostResolveRequestCache

// - MapRequestHandler/PostMapRequestHandler: MapRequestHandler срабатывает при 
//определении обработчика запроса. После выбора обработчика срабатывает событие 
//PostMapRequestHandler


// - AquireRequestState/PostAquireRequestState: событие AquireRequestState возникает
//при получении данных состояния, связанных с запросом (например, данные сессии).
//И после него срабатывает событие PostAquireRequestState

// - PreRequestHandlerExecute/PostRequestHandlerExecute: событие 
//PreRequestHandlerExecute происходит непосредственно перед началом работы 
//обработчика запроса, а событие PostRequestHandlerExecute - после его работы

// - ReleaseRequestState/PostReleaseRequestState: событие ReleaseRequestState 
//возникает, когда приложению больше не требуются данные, ассоциированные с 
//запросом.И после освобождения этих данных просиходит событие PostReleaseRequestState

// - UpdateRequestCache: возникает при обновлении данных в кэше

// - LogRequest/PostLogRequest: событие LogRequest происходит непосредственно 
//перед каждым логгированием, а PostLogRequest - после завершения всех 
//обработчиков событий

// - EndRequest: возникает при завершении обработки запроса, когда данные для
//ответа уже готовы к отправке клиенту

// - PreSendRequestHeaders: возникает перед отправкой HTTP-заголовков браузеру клиента

// - PreSendRequestContent: возникает после отправки заголовков, но перед 
//отправкой основного содержимого ответа

// - И если на определенной стадии возникнет ошибка, то сработает событие Error. 

//При необходимости можно обработать эти события, в файле Global.asax.
//Для этого надо определить в классе MvcApplication методы, имеют 
//следующее наименование: Application_[Название_события]. 

#endregion

#region Http-modules
//C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Config\web.config
//Фреймворк ASP.NET MVC уже использует ряд встроенных модулей
//для различных задач:

//AnonymousIdentification: представлен классом 
//System.Web.Security.AnonymousIdentificationModule.
//Отвечает за идентификацию запросов даже в тех случаях, 
//когда пользователь не аутентифицирован - то есть для анонимных запросов

//DefaultAuthentication: представлен классом 
//System.Web.Security.DefaultAuthenticationModule.
//Отвечает за установку свойства User у объекта HttpContext

//FileAuthorization: представлен классом 
//System.Web.Security.FileAuthorizationModule, который 
//используется при аутентификации Windows

//FormsAuthentication: представлен классом
//System.Web.Security.FormsAuthenticationModule.
//Данный модуль используется при аутентификации форм и 
//устанавливает значение свойства HttpContext.User, 
//с помощью которого мы в приложении можем получить 
//аутентифицированного пользвоателя

//OutputCache: представлен классом System.Web.Caching.OutputCacheModule.
//Отвечает за кэширование ответа клиенту

//PageInspectorHttpModule: этот модуль поддерживает функциональность 
//Page Inspector, которая имеется в Visual Studio и с помощью
//которой осуществляется отладка HTML и CSS

//Profile: представляет класс System.Web.Profile.ProfileModule,
//который связывает данные профиля пользователя с данными в запросе

//RoleManager: представлен классом System.Web.Security.RoleManagerModule,
//который управляет назначением ролей

//ScriptModule-4.0: представлен классом System.Web.Handlers.ScriptModule.
//Предназначен для поддержки Ajax-запросов

//ServiceModel-4.0: представлен классом 
//System.ServiceModel.Activation.ServiceHttpModule.
//Этот модуль используется веб-службами ASP.NET

//Session: реализован классом System.Web.SessionState.SessionStateModule.
//Предназначен для связи данных сессии с запросами

//UrlAuthorization: представлен классом System.Web.Security.UrlAuthorizationModule, 
//который обеспечивает авторизованный доступ к ресурсам

//UrlMappingsModule: представлен классом System.Web.UrlMappingsModule.
//Предназначен для поддержки функции URL Mappings, которая в ASP.NET MVC 
//не применяется

//UrlRoutingModule-4.0: реализован классом System.Web.Routing.UrlRoutingModule,
//который используется системой маршрутизации
//https://referencesource.microsoft.com/#System.Web/Routing/UrlRoutingModule.cs,9b4115ad16e4f4a1
//https://github.com/Microsoft/referencesource/blob/master/System.Web/Routing/UrlRoutingModule.cs
//WebPageHttpModule: данный модуль сопоставляет запросы с файлами представлений

//WindowsAuthentication: представляет класс 
//System.Web.Security.WindowsAuthenticationModule.
//Отвечает за аутентификацию Windows

#endregion
