import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { ItemListComponent } from './components/item-list.component';
import { NotFoundComponent } from './components/not-found.component';
import { DataService } from './data.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCardModule, MatChipsModule, MatFormFieldControl, MatFormFieldModule, MatIconModule, MatInputModule, MatMenuModule, MatProgressBarModule, MatStepperModule, MatTabsModule, MatToolbarModule } from '@angular/material';
import { ItemBodyComponent } from './components/item-body.component';
import { SettingsComponent } from './components/settings.component';
import { LoginComponent } from './components/login.component';


const appsRoutes: Routes = [
  { path: '', component: ItemListComponent },
  { path: 'body/:nameSource/:flow/:postId', component: ItemBodyComponent },
  { path: 'settings', component: SettingsComponent },
  { path: 'login', component: LoginComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    ItemListComponent,
    ItemBodyComponent,
    SettingsComponent,
    LoginComponent,
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
    MatInputModule,
    MatChipsModule

  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
