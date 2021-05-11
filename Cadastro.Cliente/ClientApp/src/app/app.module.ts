import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { GerenciarClienteComponent } from './gerenciar-cliente/gerenciar-cliente.component';
import { CadastrarClienteComponent } from './gerenciar-cliente/cadastrar-cliente/cadastrar-cliente.component';
import { NgxMaskModule } from 'ngx-mask';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CadastrarClienteComponent,
    GerenciarClienteComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgxMaskModule.forRoot(),
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: GerenciarClienteComponent },
      { path: 'gerenciar-cliente', component: GerenciarClienteComponent },
      { path: 'cadastrar-cliente', component: CadastrarClienteComponent },
      { path: 'editar-cliente/:id', component: CadastrarClienteComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
