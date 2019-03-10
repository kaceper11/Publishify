import { Component } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { PublishHistory } from '../../models/PublishHistoryModel';
import { BranchService } from '../../apiServices/branchApi.service';

@Component({
  selector: 'publish-history-modal',
  templateUrl: './publishHistoryModal.html'
})
export class PublishHistoryModal {

  constructor(private branchService: BranchService, private modalService: NgbModal) { }

  publishes: PublishHistory[];

  showPublishHistory($event) {
    this.branchService.getPublishHistory($event)
      .subscribe((data: PublishHistory[]) => this.publishes = data);
    open(content)
    {
      this.modalService.open(publishHistory)
    }

  }

  


}
