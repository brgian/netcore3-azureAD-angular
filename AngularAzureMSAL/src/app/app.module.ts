import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { WelcomeComponent } from './welcome/welcome.component';

import { MsalModule, MsalInterceptor } from "@azure/msal-angular";
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { TestService } from './test.service';

export const protectedResourceMap:[string, string[]][]=[ ['http://localhost:55680/api/authentication/test-auth',['user.read']] ];

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    MsalModule.forRoot({
      clientID: '**************************',
      authority: "https://login.microsoftonline.com/[emailaddress]hotmail.onmicrosoft.com",
      validateAuthority: true,
      redirectUri:  "http://localhost:4200/",
      cacheLocation : "localStorage",
      storeAuthStateInCookie: false,
      postLogoutRedirectUri: "http://localhost:4200/login",
      navigateToLoginRequestUrl: true,
      popUp: false,
      consentScopes: [ "user.read", "openid", "profile"],
      unprotectedResources: ["https://www.microsoft.com/en-us/"],
      protectedResourceMap: [["",[""]]],
      logger: ()=> {},
      correlationId: '9999',
      piiLoggingEnabled: true
    }),
  ],
  providers: [ TestService, {
    provide: HTTP_INTERCEPTORS,
    useClass: MsalInterceptor,
    multi: true
}
],
  bootstrap: [AppComponent]
})
export class AppModule { }
