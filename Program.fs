(* Program.fs - A simple F# application for the Angelhack challenge.
* Copyright (C) 2015 Paulo Pinto
*
* This library is free software; you can redistribute it and/or
* modify it under the terms of the GNU Lesser General Public
* License as published by the Free Software Foundation; either
* version 2 of the License, or (at your option) any later version.
*
* This library is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
* Lesser General Public License for more details.
*
* You should have received a copy of the GNU Lesser General Public
* License along with this library; if not, write to the
* Free Software Foundation, Inc., 59 Temple Place - Suite 330,
* Boston, MA 02111-1307, USA.
*)
open System.IO

// basic Braille enconding. Another option would be preferrable in real applications.
let mapping = dict [200, "a";
                    220, "b";
                    300, "c";
                    310, "d";
                    210, "e";
                    320, "f";
                    330, "g";
                    230, "h";
                    130, "j";
                    202, "k";
                    222, "l";
                    302, "m";
                    312, "n";
                    212, "o";
                    322, "p";
                    332, "q";
                    232, "r";
                    122, "s";
                    132, "t";
                    203, "u";
                    223, "v";
                    303, "x";
                    313, "y";
                    213, "z";
                    323, " and ";
                    333, " for ";
                    233, " of ";
                    123, " the ";
                    133, " with ";
                    201, "ch";
                    221, "gh";
                    301, "sh";
                    311, "th";
                    211, "wh";
                    321, "ed";
                    331, "er";
                    231, "ou";
                    121, "ow";
                    131, "w";
                    020, "-ea-";
                    022, "-bb-";
                    030, "-cc-"
                    031, "-dd-";
                    021, "en";
                    032, "ff";
                    033, "gg";
                    023, "?";
                    012, "in";
                    013, "\"";
                    002, "'"]


// translates between the two encondings
let toNum = function 
    | 'O' -> 1
    | '.' -> 0
    | x -> failwithf "Bad letter %c" x;

// encoding the full character into the dictionary key
let strToNum (str:string) = 2 * toNum str.[0] + toNum str.[1]

let pairToNum (a,b,c) = 100 * strToNum a + 10 * strToNum b + strToNum c

let toString (text:string[]) =
    text |>
    Array.map (fun (x:string) -> (x.Split(' '))) |>
    (fun a -> Array.zip3 a.[0] a.[1] a.[2]) |>
    Array.map pairToNum |>
    Array.fold (fun x y -> if mapping.ContainsKey(y) then (x + mapping.[y]) else x ) ""


[<EntryPoint>]
let main argv = 
    if argv.Length > 0 then
        let msg = File.ReadAllLines (argv.[0])
        printfn "%s" (toString msg)
        0 
    else
        printfn "No file provided"
        1


