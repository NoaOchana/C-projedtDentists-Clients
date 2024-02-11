export default class User {
    id!: string
    name!: string
    hmo!: string
    constructor(id: string, name: string,hmo: string) {

        this.id = id;
        this.name = name;
        this.hmo = hmo;
    }
}