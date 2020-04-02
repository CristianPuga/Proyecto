import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { UsuariosPageRoutingModule } from './usuarios-routing.module';

import { UsuariosPage } from './usuarios.page';
import {SplitButtonModule} from 'primeng/splitbutton';
import {ToolbarModule} from 'primeng/toolbar';
import {TableModule} from 'primeng/table';
import {DialogModule} from 'primeng/dialog';
import {DynamicDialogModule} from 'primeng/dynamicdialog';
import {PaginatorModule} from 'primeng/paginator';
import {FullCalendarModule} from 'primeng/fullcalendar';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UsuariosPageRoutingModule,
    SplitButtonModule,
    ToolbarModule,
    TableModule,
    DialogModule,
    DynamicDialogModule,
    PaginatorModule,
    FullCalendarModule
  ],
  declarations: [UsuariosPage]
})
export class UsuariosPageModule {}
