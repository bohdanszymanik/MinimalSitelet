namespace MinimalWebsite

open IntelliFactory.Html
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Sitelets

type Action =
    | Home

module Site =

    let HomePage =
        PageContent <| fun context ->
            {Page.Default with 
                Title = Some "Some title"
                Body = 
                    let time = System.DateTime.Now.ToString()
                    [H1 [Text <| "Current time: " + time]]}

[<Sealed>]
type Website() =
    interface IWebsite<Action> with
        member this.Sitelet = Sitelet.Content "/" Home Site.HomePage
        member this.Actions = []

type Global() =
    inherit System.Web.HttpApplication()

    member g.Application_Start(sender: obj, args: System.EventArgs) = ()

[<assembly: Website(typeof<Website>)>] // Website(typeof... seems to be short form of WebsiteAttribute(typeof...
do ()
