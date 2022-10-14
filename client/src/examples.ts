//implicit -- explicit
let firstName: string = "Ion";
//firstName = 33;

let firstN = "Ion";
//any
let sample1 = true;
//sample1 = "test";

let sample2: object = {};
sample2 = "string";
Math.round(sample2);
let sampleLength: number = (<string>sample2).length;
//enum
enum Day {Monday = 1, Tuesday = 2, Wednesday = 3}
let d: Day.Monday;
let day: string = Day[2];
console.log(day);
//const
const salary = 100;
const employee = {
    name: "Ion",
    salary: salary
}

employee.name = "Andrew";
employee.salary = 500;
console.log(employee);

//arrays
const days: string[] = ["Monday", "Tuesday"];
days.push("Wendnesday");
console.log(days);

//tuples
let newTuple: [boolean, string, any];
newTuple = [true, "abcdefg", 1321231];
newTuple.push("this is why readonly is used");
console.log(newTuple);

const newReadOnlyTuple: readonly [boolean, string, any] = [true, "abcdefg", 1321231];

//ternary operator
let a: number = 10,  b = 20;
a > b ? console.log("a is greater than b") : console.log("b is greater or equal to a");

//for..of
// let text = "Today is the day";

// for (var char of text) {
//   console.log(char);
// }
