import { Address } from './address';
import { Dishes } from './dishes';
export class Resturants {
  id: string;
  rName: string;
  user_id: string;
  dishlist: Dishes[];
  arrAddress: Address[];
  location: string = '';
  ROpen: boolean;
  Type:string

  constructor(
    id: string,
    n: string,
    uid: string,
    d: Dishes[],
    arrAddr: Address[],
    open: boolean,
    type:string
  ) {
    this.id = id;
    this.rName = n;
    this.user_id = uid;
    this.dishlist = d;
    this.arrAddress = arrAddr;
    this.ROpen = open;
    this.Type = type
  }
}
