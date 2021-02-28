import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './components/app.component';
import { ItemListComponent } from './components/content/item-list.component';
import { NotFoundComponent } from './components/not-found.component';
import { DataService } from './services/data.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ItemBodyComponent } from './components/content/item-body.component';
import { LoginComponent } from './components/account/login.component';
import { MatButtonModule, MatCardModule, MatChipsModule, MatFormFieldModule, MatIconModule, MatInputModule, MatListModule, MatMenuModule, MatProgressBarModule, MatSidenavModule, MatStepperModule, MatTabsModule, MatToolbarModule, MatTreeModule } from '@angular/material';
import { AboutComponent } from './components/about.component';
import { RegistrationComponent } from './components/account/registration.component';
import {AccountInfoComponent} from "./components/account/account-info.component";
import {TestComponent} from "./components/content/test.component";


const appsRoutes: Routes = [
  { path: '', component: ItemListComponent },
  { path: 'body/:nameSource/:flow/:postId', component: ItemBodyComponent },
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent },
  { path: 'dev', component: AboutComponent },
  { path: 'info', component: AccountInfoComponent },
  { path: 'test', component: TestComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    ItemListComponent,
    ItemBodyComponent,
    LoginComponent,
    RegistrationComponent,
    AboutComponent,
    AccountInfoComponent,
    NotFoundComponent,
    TestComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appsRoutes),
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatTabsModule,
    MatProgressBarModule,
    MatMenuModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatToolbarModule,
    MatStepperModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatChipsModule,
    MatSidenavModule,
    MatListModule,
    MatTreeModule

  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
