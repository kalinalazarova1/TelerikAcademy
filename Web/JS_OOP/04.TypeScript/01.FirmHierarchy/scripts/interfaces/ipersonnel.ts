interface IPersonnel {
    firstName: string;
    lastName: string;
    position: string;
    id: number;
    toString(): string;
    processPurchase(purchase: number): boolean;
}