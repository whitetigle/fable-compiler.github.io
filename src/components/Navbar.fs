module WebGenerator.Components.Navbar

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open WebGenerator.Helpers
open WebGenerator.Literals

let navButton classy href faClass txt =
  Control.div [] [
    a [Class (sprintf "button %s" classy); Href href] [
      span [Class "icon"] [
        i [Class (sprintf "fa %s" faClass)] []
      ]
      span [] [str txt ]
    ]
  ]

let navButtons =
  div [Class "navbar-item"]
    [ Field.div [ Field.IsGrouped ]
        [ navButton "twitter" "https://twitter.com/FableCompiler" "fa-twitter" "Share the love!"
          navButton "github" "https://gitter.im/fable-compiler/Fable" "fa-comments" "Chat"
          navButton "github" "https://github.com/fable-compiler/Fable" "fa-github" "Contribute" ] ]

let menuItem label page currentPage =
  a [
    classList [
      "navbar-item", true
      "is-active", System.String.Compare(page, currentPage, true) = 0
    ]
    Href page
  ] [str label]

let root currentPage =
  Navbar.navbar [] [
    Navbar.Brand.div [] [
      Navbar.Item.div [] [ Heading.h4 [] [str "Fable"] ]
      Navbar.burger [ Props [ Data("target", Navbar.MenuId)] ] [
        span [] []
        span [] []
        span [] []
      ]
    ]
    
    Navbar.menu [ Navbar.Menu.Props [Id Navbar.MenuId] ] [
      Navbar.Start.div [] [
        menuItem "Home" Navbar.Home currentPage
        menuItem "REPL" Navbar.Repl currentPage
        menuItem "Blog" Navbar.Blog currentPage
        menuItem "Docs" Navbar.Docs currentPage
        menuItem "FAQ" Navbar.FAQ currentPage
        menuItem "FableConf" Navbar.FableConf currentPage
      ]
      Navbar.End.div [] [navButtons]
    ]
  ]
 
