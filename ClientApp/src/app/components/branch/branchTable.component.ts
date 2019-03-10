import { Component, Directive, EventEmitter, Input, Output, QueryList, ViewChildren } from '@angular/core';
import { CurrentBranchInfo } from '../../models/CurrentBranchInfoModel';
import { PublishHistory } from '../../models/PublishHistoryModel';
import { BranchService } from '../../apiServices/branchApi.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'branch-table',
  templateUrl: './branchTable.html'
})
export class BranchTable {

  constructor(private branchService: BranchService, private modalService: NgbModal) {

  }

  ngOnInit() {
    this.branchService.getCurrentBranchesInfo()
      .subscribe((data: CurrentBranchInfo[]) => this.branches = data);
  }

  branches: CurrentBranchInfo[];
  publishes: PublishHistory[];

  @Output() messageEvent = new EventEmitter<string>();

  emitBranchId(branchId) {
    this.messageEvent.emit(branchId);
  }

}
