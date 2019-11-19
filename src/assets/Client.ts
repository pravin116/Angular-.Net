export class Client {
   id: number;
   FirstName: string;
   LastName: string;
   DOB: Date;
   Address: Address1[];
}

export class Address1 {
    AId: number;
    ClientId: number;
}
