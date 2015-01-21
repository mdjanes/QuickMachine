namespace QuickMachine.Core
module Utilities = 
   
   open System

   // #region Constants 
     
   /// Epsilon = 2^(-16)
   [<Literal>]
   let EPSILON:double = 0.0000000001

   // #endregion

   // #region Helper Functions

   /// DoubleEqual compare two double values up to Epsilon
   let DoubleEqual (a:double) (b:double) :bool = Math.Abs(a - b) <= EPSILON

   // #endregion

  