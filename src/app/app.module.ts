import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FormComponent } from './form/form.component';
import { HttpClientModule, HttpBackend } from '@angular/common/http';
import { EnrollmentService } from './enrollment.service';
import { FormsModule } from '@angular/forms';
import { from } from 'rxjs';
import { ResultTableComponent } from './result-table/result-table.component';
@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FormComponent,
    ResultTableComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [EnrollmentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
