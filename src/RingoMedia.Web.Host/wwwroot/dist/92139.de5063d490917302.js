"use strict";(self.webpackChunkabp_zero_template=self.webpackChunkabp_zero_template||[]).push([[92139],{92139:(F,m,i)=>{i.r(m),i.d(m,{LoginModule:()=>N});var u=i(60263),c=i(77587),f=i(64369),v=i(40506),p=i(87737),h=i(85079),e=i(6435),C=i(96111),S=i(74461),M=i(37857),y=i(11405),s=i(34182),I=i(82659),g=i(69808),b=i(26133),x=i(73565);function _(t,a){if(1&t&&e.\u0275\u0275element(0,"validation-messages",23),2&t){e.\u0275\u0275nextContext();const n=e.\u0275\u0275reference(9);e.\u0275\u0275property("formCtrl",n)}}function L(t,a){if(1&t&&e.\u0275\u0275element(0,"validation-messages",23),2&t){e.\u0275\u0275nextContext();const n=e.\u0275\u0275reference(14);e.\u0275\u0275property("formCtrl",n)}}function E(t,a){1&t&&(e.\u0275\u0275elementStart(0,"div",24),e.\u0275\u0275elementStart(1,"div",25),e.\u0275\u0275elementStart(2,"span"),e.\u0275\u0275text(3),e.\u0275\u0275pipe(4,"localize"),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd()),2&t&&(e.\u0275\u0275advance(3),e.\u0275\u0275textInterpolate(e.\u0275\u0275pipeBind1(4,1,"LoginWith")))}function T(t,a){if(1&t){const n=e.\u0275\u0275getCurrentView();e.\u0275\u0275elementStart(0,"a",28),e.\u0275\u0275listener("click",function(){const l=e.\u0275\u0275restoreView(n).$implicit;return e.\u0275\u0275nextContext(2).externalLogin(l)}),e.\u0275\u0275element(1,"i"),e.\u0275\u0275text(2),e.\u0275\u0275elementEnd()}if(2&t){const n=a.$implicit;e.\u0275\u0275propertyInterpolate("title",n.name),e.\u0275\u0275advance(1),e.\u0275\u0275classMapInterpolate1("fab fa-",n.icon,""),e.\u0275\u0275advance(1),e.\u0275\u0275textInterpolate1(" ",n.name," ")}}function O(t,a){if(1&t&&(e.\u0275\u0275elementStart(0,"div",26),e.\u0275\u0275template(1,T,3,5,"a",27),e.\u0275\u0275elementEnd()),2&t){const n=e.\u0275\u0275nextContext();e.\u0275\u0275advance(1),e.\u0275\u0275property("ngForOf",n.loginService.externalLoginProviders)}}function P(t,a){1&t&&(e.\u0275\u0275elementStart(0,"span"),e.\u0275\u0275elementStart(1,"a",29),e.\u0275\u0275text(2),e.\u0275\u0275pipe(3,"localize"),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(4,"span",30),e.\u0275\u0275text(5," | "),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd()),2&t&&(e.\u0275\u0275advance(2),e.\u0275\u0275textInterpolate(e.\u0275\u0275pipeBind1(3,1,"CreateAnAccount")))}function A(t,a){1&t&&(e.\u0275\u0275elementStart(0,"span"),e.\u0275\u0275elementStart(1,"a",31),e.\u0275\u0275text(2),e.\u0275\u0275pipe(3,"localize"),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(4,"span",30),e.\u0275\u0275text(5," | "),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd()),2&t&&(e.\u0275\u0275advance(2),e.\u0275\u0275textInterpolate(e.\u0275\u0275pipeBind1(3,1,"NewTenant")))}const w=[{path:"",component:(()=>{class t extends v.c{constructor(n,o,r,l,d,R){super(n),this.loginService=o,this._router=r,this._sessionService=l,this._sessionAppService=d,this._reCaptchaV3Service=R,this.submitting=!1,this.isMultiTenancyEnabled=this.multiTenancy.isEnabled,this.recaptchaSiteKey=h.g.recaptchaSiteKey}get multiTenancySideIsTeanant(){return this._sessionService.tenantId>0}get isTenantSelfRegistrationAllowed(){return this.setting.getBoolean("App.TenantManagement.AllowSelfRegistration")}get isSelfRegistrationAllowed(){return!!this._sessionService.tenantId&&this.setting.getBoolean("App.UserManagement.AllowSelfRegistration")}get useCaptcha(){return this.setting.getBoolean("App.UserManagement.UseCaptchaOnLogin")}ngOnInit(){this._sessionService.userId>0&&p._.getReturnUrl()&&p._.getSingleSignIn()&&this._sessionAppService.updateUserSignInToken().subscribe(n=>{const o=p._.getReturnUrl(),r=o+(o.indexOf("?")>=0?"&":"?")+"accessToken="+n.signInToken+"&userId="+n.encodedUserId+"&tenantId="+n.encodedTenantId;location.href=r}),this.handleExternalLoginCallbacks()}handleExternalLoginCallbacks(){let n=p._.getQueryParametersUsingHash().state,o=p._.getQueryParameters();if(n&&n.indexOf("openIdConnect")>=0&&this.loginService.openIdConnectLoginCallback({}),o.state&&o.state.indexOf("openIdConnect")>=0&&this.loginService.openIdConnectLoginCallback({}),o.twitter&&"1"===o.twitter){let r=p._.getQueryParameters();this.loginService.twitterLoginCallback(r.oauth_token,r.oauth_verifier)}}login(){let n=o=>{this.showMainSpinner(),this.submitting=!0,this.loginService.authenticate(()=>{this.submitting=!1,this.hideMainSpinner()},null,o)};this.useCaptcha?this._reCaptchaV3Service.execute(this.recaptchaSiteKey,"login",o=>{n(o)}):n(null)}externalLogin(n){this.loginService.externalAuthenticate(n)}}return t.\u0275fac=function(n){return new(n||t)(e.\u0275\u0275directiveInject(e.Injector),e.\u0275\u0275directiveInject(C.r),e.\u0275\u0275directiveInject(c.F0),e.\u0275\u0275directiveInject(S.Cr),e.\u0275\u0275directiveInject(M.HQ),e.\u0275\u0275directiveInject(y.YC))},t.\u0275cmp=e.\u0275\u0275defineComponent({type:t,selectors:[["ng-component"]],features:[e.\u0275\u0275InheritDefinitionFeature],decls:42,vars:35,consts:[[1,"login-form"],[1,"pb-13","pt-lg-0","pt-5"],[1,"fw-bolder","text-dark","fs-h4","fs-h1-lg"],["method","post",1,"login-form","form",3,"ngSubmit"],["loginForm","ngForm"],[1,"mb-5"],["autoFocus","","type","text","autocomplete","new-password","name","userNameOrEmailAddress","required","",1,"form-control","form-control-solid","h-auto","py-7","px-6","rounded-lg","fs-h6",3,"ngModel","placeholder","ngModelChange"],["userNameOrEmailAddressInput","ngModel"],[3,"formCtrl",4,"ngIf"],["type","password","autocomplete","new-password","name","password","required","","maxlength","32",1,"form-control","form-control-solid","h-auto","py-7","px-6","rounded-lg","fs-h6",3,"ngModel","placeholder","ngModelChange"],["passwordInput","ngModel"],[1,"mb-5","d-flex","justify-content-between","mt-4"],[1,"form-check","form-check-custom","form-check-solid"],["type","checkbox","name","rememberMe","value","true",1,"form-check-input",3,"ngModel","ngModelChange"],[1,"form-check-label"],["routerLink","/account/forgot-password","id","forget-password",1,"text-primary","fs-h6","fw-bolder","text-hover-primary"],[1,"pb-lg-0","pb-5"],["type","submit",1,"btn","w-100","btn-primary","fw-bolder","fs-h6","px-8","py-4","my-3","me-3",3,"disabled"],["class","mt-10 mb-2",4,"ngIf"],["class","pb-lg-0 pb-5 login__options",4,"ngIf"],[1,"mt-5"],[4,"ngIf"],["routerLink","/account/email-activation","id","email-activation-btn"],[3,"formCtrl"],[1,"mt-10","mb-2"],[1,"divider"],[1,"pb-lg-0","pb-5","login__options"],["class","btn btn-sm btn-light-primary fw-bolder py-2 mb-2 ml-0 me-2",3,"title","click",4,"ngFor","ngForOf"],[1,"btn","btn-sm","btn-light-primary","fw-bolder","py-2","mb-2","ml-0","me-2",3,"title","click"],["routerLink","/account/register"],[1,"pipe-divider"],["routerLink","/account/select-edition"]],template:function(n,o){if(1&n&&(e.\u0275\u0275elementStart(0,"div",0),e.\u0275\u0275elementStart(1,"div",1),e.\u0275\u0275elementStart(2,"h3",2),e.\u0275\u0275text(3),e.\u0275\u0275pipe(4,"localize"),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(5,"form",3,4),e.\u0275\u0275listener("ngSubmit",function(){return o.login()}),e.\u0275\u0275elementStart(7,"div",5),e.\u0275\u0275elementStart(8,"input",6,7),e.\u0275\u0275listener("ngModelChange",function(l){return o.loginService.authenticateModel.userNameOrEmailAddress=l}),e.\u0275\u0275pipe(10,"localize"),e.\u0275\u0275elementEnd(),e.\u0275\u0275template(11,_,1,1,"validation-messages",8),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(12,"div",5),e.\u0275\u0275elementStart(13,"input",9,10),e.\u0275\u0275listener("ngModelChange",function(l){return o.loginService.authenticateModel.password=l}),e.\u0275\u0275pipe(15,"localize"),e.\u0275\u0275elementEnd(),e.\u0275\u0275template(16,L,1,1,"validation-messages",8),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(17,"div",11),e.\u0275\u0275elementStart(18,"label",12),e.\u0275\u0275elementStart(19,"input",13),e.\u0275\u0275listener("ngModelChange",function(l){return o.loginService.rememberMe=l}),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(20,"span",14),e.\u0275\u0275text(21),e.\u0275\u0275pipe(22,"localize"),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(23,"a",15),e.\u0275\u0275text(24),e.\u0275\u0275pipe(25,"localize"),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(26,"div",16),e.\u0275\u0275elementStart(27,"button",17),e.\u0275\u0275text(28),e.\u0275\u0275pipe(29,"localize"),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275template(30,E,5,3,"div",18),e.\u0275\u0275template(31,O,2,1,"div",19),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(32,"div",20),e.\u0275\u0275elementStart(33,"div"),e.\u0275\u0275elementStart(34,"span"),e.\u0275\u0275text(35),e.\u0275\u0275pipe(36,"localize"),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275template(37,P,6,3,"span",21),e.\u0275\u0275template(38,A,6,3,"span",21),e.\u0275\u0275elementStart(39,"a",22),e.\u0275\u0275text(40),e.\u0275\u0275pipe(41,"localize"),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd()),2&n){const r=e.\u0275\u0275reference(6),l=e.\u0275\u0275reference(9),d=e.\u0275\u0275reference(14);e.\u0275\u0275property("@routerTransition",void 0),e.\u0275\u0275advance(3),e.\u0275\u0275textInterpolate(e.\u0275\u0275pipeBind1(4,19,"LogIn")),e.\u0275\u0275advance(5),e.\u0275\u0275propertyInterpolate1("placeholder","",e.\u0275\u0275pipeBind1(10,21,"UserNameOrEmail")," *"),e.\u0275\u0275property("ngModel",o.loginService.authenticateModel.userNameOrEmailAddress),e.\u0275\u0275advance(3),e.\u0275\u0275property("ngIf",!l.touched),e.\u0275\u0275advance(2),e.\u0275\u0275propertyInterpolate1("placeholder","",e.\u0275\u0275pipeBind1(15,23,"Password")," *"),e.\u0275\u0275property("ngModel",o.loginService.authenticateModel.password),e.\u0275\u0275advance(3),e.\u0275\u0275property("ngIf",!d.touched),e.\u0275\u0275advance(3),e.\u0275\u0275property("ngModel",o.loginService.rememberMe),e.\u0275\u0275advance(2),e.\u0275\u0275textInterpolate1(" ",e.\u0275\u0275pipeBind1(22,25,"RememberMe")," "),e.\u0275\u0275advance(3),e.\u0275\u0275textInterpolate(e.\u0275\u0275pipeBind1(25,27,"ForgotPassword")),e.\u0275\u0275advance(3),e.\u0275\u0275property("disabled",!r.form.valid),e.\u0275\u0275advance(1),e.\u0275\u0275textInterpolate(e.\u0275\u0275pipeBind1(29,29,"LogIn")),e.\u0275\u0275advance(2),e.\u0275\u0275property("ngIf",(o.multiTenancySideIsTeanant||!o.isMultiTenancyEnabled)&&o.loginService.externalLoginProviders.length>0),e.\u0275\u0275advance(1),e.\u0275\u0275property("ngIf",(o.multiTenancySideIsTeanant||!o.isMultiTenancyEnabled)&&o.loginService.externalLoginProviders.length>0),e.\u0275\u0275advance(4),e.\u0275\u0275textInterpolate(e.\u0275\u0275pipeBind1(36,31,"NotAMemberYet")),e.\u0275\u0275advance(2),e.\u0275\u0275property("ngIf",o.isSelfRegistrationAllowed),e.\u0275\u0275advance(1),e.\u0275\u0275property("ngIf",!o.multiTenancySideIsTeanant&&o.isTenantSelfRegistrationAllowed),e.\u0275\u0275advance(2),e.\u0275\u0275textInterpolate(e.\u0275\u0275pipeBind1(41,33,"EmailActivation"))}},directives:[s.\u0275NgNoValidate,s.NgControlStatusGroup,s.NgForm,s.DefaultValueAccessor,I.h,s.RequiredValidator,s.NgControlStatus,s.NgModel,g.O5,s.MaxLengthValidator,s.CheckboxControlValueAccessor,c.yS,b.s,g.sg],pipes:[x.F],styles:['.login__options[_ngcontent-%COMP%]   a[_ngcontent-%COMP%]{cursor:pointer}.login__options[_ngcontent-%COMP%]   a.btn[_ngcontent-%COMP%] + .btn[_ngcontent-%COMP%]{margin-left:0!important}.login__options[_ngcontent-%COMP%]   a[_ngcontent-%COMP%]   i.fa-openidconnect[_ngcontent-%COMP%]:before{content:"\\f19b"}.login__options[_ngcontent-%COMP%]   a[_ngcontent-%COMP%]   i.fa-wsfederation[_ngcontent-%COMP%]{margin-right:2px}.login__options[_ngcontent-%COMP%]   a[_ngcontent-%COMP%]   i.fa-wsfederation[_ngcontent-%COMP%]:before{content:"\\f20e"}'],data:{animation:[(0,f.RP)()]}}),t})(),pathMatch:"full"}];let z=(()=>{class t{}return t.\u0275fac=function(n){return new(n||t)},t.\u0275mod=e.\u0275\u0275defineNgModule({type:t}),t.\u0275inj=e.\u0275\u0275defineInjector({imports:[[c.Bz.forChild(w)],c.Bz]}),t})();var B=i(12749);let N=(()=>{class t{}return t.\u0275fac=function(n){return new(n||t)},t.\u0275mod=e.\u0275\u0275defineNgModule({type:t}),t.\u0275inj=e.\u0275\u0275defineInjector({imports:[[u.o,B.y,z]]}),t})()}}]);