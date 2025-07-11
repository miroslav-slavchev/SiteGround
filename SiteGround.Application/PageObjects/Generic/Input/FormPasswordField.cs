﻿using PlayWright.Library.Components.Context;
using PlayWright.Library.Components;
using SiteGround.Application.UiElements.Inputs;
using SiteGround.Application.UiElements.Buttons.SwitchButtons;
using SiteGround.Application.UiElements.Buttons;

namespace SiteGround.Application.PageObjects.Generic.Input
{
    public class FormPasswordField(SearchContext searchContext, By by) : PageObject(searchContext, by)
    {
        public TextInput Input => UiElement<TextInput>(Locate.By("css=input[data-e2e=form-password-password]"));
        public ShowHideButton ShowOrHideButton => UiElement<ShowHideButton>();
        public Button GenerateButton => UiElement<Button>(Locate.By("css=button[data-e2e=password-generate]"));
        public Button CopyButton => UiElement<Button>(Locate.BySelector("css=button").WithText("Copy").Build());
        public Button ReGenerateButton => UiElement<Button>(Locate.By("css=span[data-icon=refresh]"));
    }
}
