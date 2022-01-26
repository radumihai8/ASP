import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import {HomeComponent} from "./home/home.component";
import {LayoutComponent} from "./layout/layout.component";
import {AuthGuard} from "./guards/auth.guard";
import {ArticleComponent} from "./article/article.component";
import {RegisterComponent} from "./register/register.component";
import {CreateComponent} from "./create/create.component";
import {AdminGuard} from "./guards/admin.guard";
import {VisitorGuard} from "./guards/visitor.guard";

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,

    children: [
      { path: 'login', component: LoginComponent, canActivate: [VisitorGuard] },
      { path: 'register', component: RegisterComponent, canActivate: [VisitorGuard] },
      { path: 'create', component: CreateComponent, canActivate: [AdminGuard] },
      { path: 'article/:id', component: ArticleComponent },
      { path: 'category/:id', component: HomeComponent },
      { path: '', component: HomeComponent }

    ],
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
