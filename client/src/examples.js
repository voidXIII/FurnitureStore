//implicit -- explicit
var firstName = "Ion";
//firstName = 33;
var firstN = "Ion";
//any
var sample1 = true;
//sample1 = "test";
var sample2 = true;
sample2 = "string";
Math.round(sample2);
var sampleLength = sample2.length;
//enum
var Day;
(function (Day) {
    Day[Day["Monday"] = 1] = "Monday";
    Day[Day["Tuesday"] = 2] = "Tuesday";
    Day[Day["Wednesday"] = 3] = "Wednesday";
})(Day || (Day = {}));
var d;
var day = Day[2];
console.log(day);
//const
var salary = 100;
var employee = {
    name: "Ion",
    salary: salary
};
employee.name = "Andrew";
employee.salary = 500;
console.log(employee);
//arrays
var days = ["Monday", "Tuesday"];
days.push("Wendnesday");
console.log(days);
//tuples
var newTuple;
newTuple = [true, "abcdefg", 1321231];
newTuple.push("this is why readonly is used");
console.log(newTuple);
var newReadOnlyTuple = [true, "abcdefg", 1321231];
//ternary operator
var a = 10, b = 20;
a > b ? console.log("a is greater than b") : console.log("b is greater or equal to a");
//for..of
// let text = "Today is the day";
// for (var char of text) {
//   console.log(char);
// }
