"use strict";(self.webpackChunkabp_zero_template=self.webpackChunkabp_zero_template||[]).push([[15524],{15524:(M,s,n)=>{n.r(s),n.d(s,{SendTwoFactorCodeModule:()=>I});var p=n(60263),v=n(12749),c=n(77587),f=n(64369),g=n(40506),u=n(37857),h=n(40537),e=n(6435),S=n(96111),m=n(69808),i=n(34182),C=n(82659),F=n(73565);function T(t,r){if(1&t&&(e.\u0275\u0275elementStart(0,"option",11),e.\u0275\u0275text(1),e.\u0275\u0275elementEnd()),2&t){const o=r.$implicit;e.\u0275\u0275property("value",o),e.\u0275\u0275advance(1),e.\u0275\u0275textInterpolate1(" ",o," ")}}function w(t,r){if(1&t){const o=e.\u0275\u0275getCurrentView();e.\u0275\u0275elementStart(0,"form",4,5),e.\u0275\u0275listener("ngSubmit",function(){return e.\u0275\u0275restoreView(o),e.\u0275\u0275nextContext().submit()}),e.\u0275\u0275elementStart(2,"p"),e.\u0275\u0275text(3),e.\u0275\u0275pipe(4,"localize"),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(5,"div",6),e.\u0275\u0275elementStart(6,"select",7),e.\u0275\u0275listener("ngModelChange",function(l){return e.\u0275\u0275restoreView(o),e.\u0275\u0275nextContext().selectedTwoFactorProvider=l}),e.\u0275\u0275template(7,T,2,2,"option",8),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(8,"div",9),e.\u0275\u0275elementStart(9,"button",10),e.\u0275\u0275text(10),e.\u0275\u0275pipe(11,"localize"),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd()}if(2&t){const o=e.\u0275\u0275nextContext();e.\u0275\u0275advance(3),e.\u0275\u0275textInterpolate(e.\u0275\u0275pipeBind1(4,4,"SendSecurityCode_Information")),e.\u0275\u0275advance(3),e.\u0275\u0275property("ngModel",o.selectedTwoFactorProvider),e.\u0275\u0275advance(1),e.\u0275\u0275property("ngForOf",o.loginService.authenticateResult.twoFactorAuthProviders),e.\u0275\u0275advance(3),e.\u0275\u0275textInterpolate1(" ",e.\u0275\u0275pipeBind1(11,6,"Submit")," ")}}const x=[{path:"",component:(()=>{class t extends g.c{constructor(o,a,l,d){super(o),this.loginService=a,this._tokenAuthService=l,this._router=d,this.submitting=!1}canActivate(){return!!(this.loginService.authenticateModel&&this.loginService.authenticateResult&&this.loginService.authenticateResult.twoFactorAuthProviders&&this.loginService.authenticateResult.twoFactorAuthProviders.length)}ngOnInit(){this.canActivate()?this.selectedTwoFactorProvider=this.loginService.authenticateResult.twoFactorAuthProviders[0]:this._router.navigate(["account/login"])}submit(){const o=new u.F6;o.userId=this.loginService.authenticateResult.userId,o.provider=this.selectedTwoFactorProvider,this.submitting=!0,this._tokenAuthService.sendTwoFactorAuthCode(o).pipe((0,h.x)(()=>this.submitting=!1)).subscribe(()=>{this._router.navigate(["account/verify-code"])})}}return t.\u0275fac=function(o){return new(o||t)(e.\u0275\u0275directiveInject(e.Injector),e.\u0275\u0275directiveInject(S.r),e.\u0275\u0275directiveInject(u.WH),e.\u0275\u0275directiveInject(c.F0))},t.\u0275cmp=e.\u0275\u0275defineComponent({type:t,selectors:[["ng-component"]],features:[e.\u0275\u0275InheritDefinitionFeature],decls:6,vars:5,consts:[[1,"login-form"],[1,"pb-13","pt-lg-0","pt-5"],[1,"fw-bolder","text-dark","fs-h4","fs-h1-lg"],["class","login-form form","method","post",3,"ngSubmit",4,"ngIf"],["method","post",1,"login-form","form",3,"ngSubmit"],["twoFactorForm","ngForm"],[1,"mb-5"],["autoFocus","","size","1","name","selectedTwoFactorProvider",1,"form-control","form-control-solid","h-auto","py-7","px-6","rounded-lg","fs-h6",3,"ngModel","ngModelChange"],[3,"value",4,"ngFor","ngForOf"],[1,"pb-lg-0","pb-5"],["type","submit",1,"btn","btn-primary","fw-bolder","fs-h6","px-8","py-4","my-3","me-3"],[3,"value"]],template:function(o,a){1&o&&(e.\u0275\u0275elementStart(0,"div",0),e.\u0275\u0275elementStart(1,"div",1),e.\u0275\u0275elementStart(2,"h3",2),e.\u0275\u0275text(3),e.\u0275\u0275pipe(4,"localize"),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementEnd(),e.\u0275\u0275template(5,w,12,8,"form",3),e.\u0275\u0275elementEnd()),2&o&&(e.\u0275\u0275property("@routerTransition",void 0),e.\u0275\u0275advance(3),e.\u0275\u0275textInterpolate1(" ",e.\u0275\u0275pipeBind1(4,3,"SendSecurityCode")," "),e.\u0275\u0275advance(2),e.\u0275\u0275property("ngIf",a.loginService.authenticateResult))},directives:[m.O5,i.\u0275NgNoValidate,i.NgControlStatusGroup,i.NgForm,i.SelectControlValueAccessor,C.h,i.NgControlStatus,i.NgModel,m.sg,i.NgSelectOption,i.\u0275NgSelectMultipleOption],pipes:[F.F],encapsulation:2,data:{animation:[(0,f.RP)()]}}),t})(),pathMatch:"full"}];let y=(()=>{class t{}return t.\u0275fac=function(o){return new(o||t)},t.\u0275mod=e.\u0275\u0275defineNgModule({type:t}),t.\u0275inj=e.\u0275\u0275defineInjector({imports:[[c.Bz.forChild(x)],c.Bz]}),t})(),I=(()=>{class t{}return t.\u0275fac=function(o){return new(o||t)},t.\u0275mod=e.\u0275\u0275defineNgModule({type:t}),t.\u0275inj=e.\u0275\u0275defineInjector({imports:[[p.o,v.y,y]]}),t})()}}]);