import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-panel-widget',
  templateUrl: './panel-widget.component.html',
  styleUrls: ['./panel-widget.component.scss'],
})
export class PanelWidgetComponent implements OnInit {

  @Input() icon:String ;
  @Input() panelInformation:String;
  @Input() panelFooter:String ;

  constructor(private router: Router) { }

  ngOnInit() {
  }

}
