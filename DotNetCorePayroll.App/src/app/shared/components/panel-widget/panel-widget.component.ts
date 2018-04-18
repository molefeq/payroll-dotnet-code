import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-panel-widget',
  templateUrl: './panel-widget.component.html',
  styleUrls: ['./panel-widget.component.scss'],
})
export class PanelWidgetComponent implements OnInit {

  @Input() icon:String ;
  @Input() panelInformation:String;
  @Input() panelFooter:String ;

  constructor() { }

  ngOnInit() {
  }

}
