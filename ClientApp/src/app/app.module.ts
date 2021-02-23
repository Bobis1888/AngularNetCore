import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './components/app.component';
import { ItemListComponent } from './components/item-list.component';
import { NotFoundComponent } from './components/not-found.component';
import { DataService } from './services/data.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ItemBodyComponent } from './components/item-body.component';
import { SettingsComponent } from './components/settings.component';
import { LoginComponent } from './components/login.component';
import { MatButtonModule, MatCardModule, MatChipsModule, MatFormFieldModule, MatIconModule, MatInputModule, MatListModule, MatMenuModule, MatProgressBarModule, MatSidenavModule, MatStepperModule, MatTabsModule, MatToolbarModule } from '@angular/material';
import { AboutComponent } from './components/about.component';


const appsRoutes: Routes = [
  { path: '', component: ItemListComponent },
  { path: 'body/:nameSource/:flow/:postId', component: ItemBodyComponent },
  { path: 'settings', component: SettingsComponent },
  { path: 'login', component: LoginComponent },
  { path: 'dev', component: AboutComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    ItemListComponent,
    ItemBodyComponent,
    SettingsComponent,
    LoginComponent,
    AboutComponent,
    NotFoundComponent,

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
    MatListModule

  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
