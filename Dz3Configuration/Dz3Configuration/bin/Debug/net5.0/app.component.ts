import { Component } from '@angular/core';
import { Title } from 'project/titles';
import { Child } from 'project/childs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular-project';
  count = 100;
}
