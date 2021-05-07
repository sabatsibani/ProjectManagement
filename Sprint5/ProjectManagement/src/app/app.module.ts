import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import {RouterModule, Routes} from "@angular/router";
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';

import { LoginUserComponent } from './User/LoginUser.component';
import { HomeScreenComponent } from './Home/HomeScreen.component';

import { HomeProjectComponent } from './Project/HomeProject.component';
import { CreateProjectComponent } from './Project/CreateProject.component';
import { UpdateProjectComponent } from './Project/UpdateProject.component';

import { HomeTaskComponent } from './Task/HomeTask.component';
import { UpdateTaskComponent } from './Task/UpdateTask.component';
import { CreateTaskComponent } from './Task/CreateTask.component';

import { HomeUserComponent } from './User/HomeUser.component';
import { UpdateUserComponent } from './User/UpdateUser.component';
import { CreateUserComponent } from './User/CreateUser.component';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

const routes: Routes = [
  { path: 'Login', component: LoginUserComponent },
  { path: 'Home', component: HomeScreenComponent },
  { path: 'Project', component: HomeProjectComponent },
  { path: 'ProjectCreate', component: CreateProjectComponent },
  { path: 'ProjectUpdate', component: UpdateProjectComponent },
  { path: 'Task', component: HomeTaskComponent },
  { path: 'TaskCreate', component: CreateTaskComponent },
  { path: 'TaskUpdate', component: UpdateTaskComponent },
  { path: 'User', component: HomeUserComponent },
  { path: 'UserCreate', component: CreateUserComponent },
  { path: 'UserUpdate', component: UpdateUserComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    LoginUserComponent,
    HomeScreenComponent,
    HomeProjectComponent,
    CreateProjectComponent,
    UpdateProjectComponent,
    HomeTaskComponent,
    CreateTaskComponent,
    UpdateTaskComponent,
    HomeUserComponent,
    CreateUserComponent,
    UpdateUserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(routes),FormsModule,HttpClientModule],
    exports: [RouterModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
