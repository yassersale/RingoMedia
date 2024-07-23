"use strict";(self.webpackChunkabp_zero_template=self.webpackChunkabp_zero_template||[]).push([[38404],{38404:(L,m,r)=>{r.r(m),r.d(m,{SessionLockScreenModule:()=>k});var p=r(60263),u=r(12749),d=r(77587),f=r(40506),g=r(64369),c=r(85079),e=r(6435),S=r(37857),h=r(11405),v=r(96111),C=r(69808),a=r(34182),y=r(26133),I=r(73565);function b(t,l){if(1&t&&e.\u0275\u0275element(0,"img",25),2&t){const o=e.\u0275\u0275nextContext();e.\u0275\u0275property("src",o.userInfo.profilePicture,e.\u0275\u0275sanitizeUrl)}}function M(t,l){if(1&t&&e.\u0275\u0275element(0,"validation-messages",26),2&t){e.\u0275\u0275nextContext();const o=e.\u0275\u0275reference(25);e.\u0275\u0275property("formCtrl",o)}}const x=[{path:"",component:(()=>{class t extends f.c{constructor(o,n,i,s){super(o),this._profileService=n,this._reCaptchaV3Service=i,this.loginService=s,this.recaptchaSiteKey=c.g.recaptchaSiteKey,this.submitting=!1,this.getLastUserInfo()}get useCaptcha(){return this.setting.getBoolean("App.UserManagement.UseCaptchaOnLogin")}getLastUserInfo(){let o=abp.utils.getCookieValue("userInfo");o||(location.href="");let n=JSON.parse(o);n||(location.href=""),this.loginService.authenticateModel.userNameOrEmailAddress=n.userName,this.userInfo={userName:n.userName,tenant:n.tenant,profilePicture:""},this._profileService.getProfilePictureByUserName(n.userName).subscribe(i=>{this.userInfo.profilePicture=i.profilePicture?"data:image/jpeg;base64,"+i.profilePicture:c.g.appBaseUrl+"/assets/common/images/default-profile-picture.png"},()=>{this.userInfo.profilePicture=c.g.appBaseUrl+"/assets/common/images/default-profile-picture.png"})}login(){let o=n=>{this.showMainSpinner(),this.submitting=!0,this.loginService.authenticate(()=>{this.submitting=!1,this.hideMainSpinner()},null,n)};this.useCaptcha?this._reCaptchaV3Service.execute(this.recaptchaSiteKey,"login",n=>{o(n)}):o(null)}}return t.\u0275fac=function(o){return new(o||t)(e.\u0275\u0275directiveInject(e.Injector),e.\u0275\u0275directiveInject(S.qA),e.\u0275\u0275directiveInject(h.YC),e.\u0275\u0275directiveInject(v.r))},t.\u0275cmp=e.\u0275\u0275defineComponent({type:t,selectors:[["app-session-lock-screen"]],features:[e.\u0275\u0275InheritDefinitionFeature],decls:38,vars:20,consts:[[1,"card","card-bordered","gutter-b","card-stretch"],[1,"card-body","text-center","pt-4"],["role","alert",1,"alert","bg-light-primary"],[1,"alert-text",2,"font-weight","bold"],[1,"fa","fa-lock","float-end","mt-1","me-5"],[1,"mt-7","pb-2"],[1,"symbol","symbol-circle","symbol-lg-75"],["class","symbol-label","alt","profileimage",3,"src",4,"ngIf"],[1,"my-2"],["href","#",1,"text-dark","fw-bold","text-hover-primary","fs-h4"],[1,"text-dark","fw-normal","fs-h4"],[1,"text-dark","fw-bold"],["method","post","novalidate","",1,"form","mt-4",3,"ngSubmit"],["loginForm","ngForm"],[1,"mb-5"],["type","hidden","name","usernameOrEmailAddress"],["type","password","autocomplete","new-password","name","password","required","","maxlength","32",1,"form-control","form-control-solid","h-auto","py-7","px-6","rounded-lg","fs-h6",3,"ngModel","placeholder","ngModelChange"],["passwordInput","ngModel"],[3,"formCtrl",4,"ngIf"],[1,"mt-9","mb-6"],[1,"col-5","mt-2","float-start"],[1,"form-check","form-check-custom","form-check-solid","py-1"],["type","checkbox","name","rememberMe","value","true",1,"form-check-input",3,"ngModel","ngModelChange"],[1,"form-check-label"],["type","submit",1,"btn","btn-primary","fw-bolder","fs-h6","col-5","float-end",3,"disabled"],["alt","profileimage",1,"symbol-label",3,"src"],[3,"formCtrl"]],template:function(o,n){if(1&o&&(e.\u0275\u0275elementStart(0,"div",0),e.\u0275\u0275elementStart(1,"div",1),e.\u0275\u0275elementStart(2,"div",2),e.\u0275\u0275elementStart(3,"div",3),e.\u0275\u0275text(4),e.\u0275\u0275pipe(5,"localize"),e.\u0275\u0275element(6,"i",4),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(7,"div",5),e.\u0275\u0275elementStart(8,"div",6),e.\u0275\u0275template(9,b,1,1,"img",7),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(10,"div",8),e.\u0275\u0275elementStart(11,"a",9),e.\u0275\u0275text(12),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(13,"div",8),e.\u0275\u0275elementStart(14,"span",10),e.\u0275\u0275text(15," Tenant: "),e.\u0275\u0275elementStart(16,"span",11),e.\u0275\u0275text(17),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(18,"form",12,13),e.\u0275\u0275listener("ngSubmit",function(){return n.login()}),e.\u0275\u0275elementStart(20,"div",8),e.\u0275\u0275elementStart(21,"div",14),e.\u0275\u0275element(22,"input",15),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(23,"div",14),e.\u0275\u0275elementStart(24,"input",16,17),e.\u0275\u0275listener("ngModelChange",function(s){return n.loginService.authenticateModel.password=s}),e.\u0275\u0275pipe(26,"localize"),e.\u0275\u0275elementEnd(),e.\u0275\u0275template(27,M,1,1,"validation-messages",18),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(28,"div",19),e.\u0275\u0275elementStart(29,"div",20),e.\u0275\u0275elementStart(30,"label",21),e.\u0275\u0275elementStart(31,"input",22),e.\u0275\u0275listener("ngModelChange",function(s){return n.loginService.rememberMe=s}),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(32,"span",23),e.\u0275\u0275text(33),e.\u0275\u0275pipe(34,"localize"),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(35,"button",24),e.\u0275\u0275text(36),e.\u0275\u0275pipe(37,"localize"),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd()),2&o){const i=e.\u0275\u0275reference(19),s=e.\u0275\u0275reference(25);e.\u0275\u0275property("@routerTransition",void 0),e.\u0275\u0275advance(4),e.\u0275\u0275textInterpolate1(" ",e.\u0275\u0275pipeBind1(5,12,"YourSessionIsLocked")," "),e.\u0275\u0275advance(5),e.\u0275\u0275property("ngIf",n.userInfo&&n.userInfo.profilePicture),e.\u0275\u0275advance(3),e.\u0275\u0275textInterpolate(n.userInfo.userName),e.\u0275\u0275advance(5),e.\u0275\u0275textInterpolate(n.userInfo.tenant),e.\u0275\u0275advance(7),e.\u0275\u0275propertyInterpolate1("placeholder","",e.\u0275\u0275pipeBind1(26,14,"Password"),"*"),e.\u0275\u0275property("ngModel",n.loginService.authenticateModel.password),e.\u0275\u0275advance(3),e.\u0275\u0275property("ngIf",!s.touched),e.\u0275\u0275advance(4),e.\u0275\u0275property("ngModel",n.loginService.rememberMe),e.\u0275\u0275advance(2),e.\u0275\u0275textInterpolate1(" ",e.\u0275\u0275pipeBind1(34,16,"RememberMe")," "),e.\u0275\u0275advance(2),e.\u0275\u0275property("disabled",!i.form.valid),e.\u0275\u0275advance(1),e.\u0275\u0275textInterpolate1(" ",e.\u0275\u0275pipeBind1(37,18,"LogIn")," ")}},directives:[C.O5,a.\u0275NgNoValidate,a.NgControlStatusGroup,a.NgForm,a.DefaultValueAccessor,a.RequiredValidator,a.MaxLengthValidator,a.NgControlStatus,a.NgModel,a.CheckboxControlValueAccessor,y.s],pipes:[I.F],styles:["app-session-lock-screen[_ngcontent-%COMP%]{display:flex;flex:1;flex-direction:column}"],data:{animation:[(0,g.RP)()]}}),t})()}];let E=(()=>{class t{}return t.\u0275fac=function(o){return new(o||t)},t.\u0275mod=e.\u0275\u0275defineNgModule({type:t}),t.\u0275inj=e.\u0275\u0275defineInjector({imports:[[d.Bz.forChild(x)],d.Bz]}),t})(),k=(()=>{class t{}return t.\u0275fac=function(o){return new(o||t)},t.\u0275mod=e.\u0275\u0275defineNgModule({type:t}),t.\u0275inj=e.\u0275\u0275defineInjector({imports:[[p.o,u.y,E]]}),t})()}}]);