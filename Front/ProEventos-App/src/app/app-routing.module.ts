import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { EventosComponent} from './Components/eventos/eventos.component';
import { PalestrantesComponent } from './Components/palestrantes/palestrantes.component';
import { PerfilComponent } from './Components/perfil/perfil.component';
import { ContatosComponent } from './contatos/contatos.component';


const routes: Routes = [
  {path : 'eventos', component : EventosComponent},
  {path : 'palestrantes', component : PalestrantesComponent},
  {path : 'perfil', component : PerfilComponent},
  {path : 'dashboard', component : DashboardComponent},
  {path : 'contatos', component : ContatosComponent},
  {path : '', redirectTo:'dashboard', pathMatch: 'full'},
  {path : '**', redirectTo:'dashboard', pathMatch: 'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
