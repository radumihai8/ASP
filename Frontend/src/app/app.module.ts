import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent} from "./login/login.component";

import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import {MaterialModule} from "./material/material.module";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import { LayoutComponent } from './layout/layout.component';
import { ArticleComponent } from './article/article.component';
import { RegisterComponent } from './register/register.component';
import {CreateComponent} from "./create/create.component";
import {MatSelectModule} from "@angular/material/select";
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    LayoutComponent,
    ArticleComponent,
    RegisterComponent,
    CreateComponent,

  ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        ReactiveFormsModule,
        MaterialModule,
        HttpClientModule,
        MatSelectModule,
        ToastrModule.forRoot()
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
