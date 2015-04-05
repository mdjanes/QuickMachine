namespace QuickMachine.Core

   open System
   open System.Globalization

   /// Angle type pass radian value to create
   [<Struct; CustomComparison; CustomEquality>]
   type Angle (radians:double) = 
   
      // #region Properties
      
      /// Get radian value [0, 2*Math.PI)
      member this.Radians = radians % (2.0*Math.PI) |> fun value -> if value < 0.0 then value + (2.0*Math.PI) else value
      /// Get Degree value [0, 360)
      member this.Degrees = this.Radians * (180.0/Math.PI)
      
      // #endregion

      // #region override

      /// Override equality. Two angles are equal if they have
      /// the same radian value.  Note that this method does NOT
      /// use the DoubleEqual method since all angles would then
      /// have to hash the to the same value.
      override this.Equals(obj) = 
         match obj with
            | :? Angle as obj -> this.Radians = obj.Radians
            | _ -> invalidArg "obj" "not an Angle"


      /// Override hash method to hash radian value
      override this.GetHashCode() = hash this.Radians

      /// Print radians
      override this.ToString() = this.Radians.ToString(CultureInfo.InvariantCulture)

      // #endregion

      // #region ICompariable

      interface IComparable<Angle> with
         /// a.CompareTo b -> 
         /// 0 if a = b
         /// 1 if a > b or a is within 180 degrees counter clockwise of b
         ///-1 if a < b or b is within 180 degrees counter clockwise of a
         member this.CompareTo obj = 
            if  this.Equals(obj) then 0 else 
               match (int (this.Radians / Math.PI), int (obj.Radians / Math.PI)) with
                  | (0,0) | (1,1) -> this.Radians.CompareTo obj.Radians
                  | (0, 1) -> if (obj.Radians - this.Radians) - Utilities.EPSILON < Math.PI then -1 else 1
                  | (1, 0) -> if (this.Radians - obj.Radians) + Utilities.EPSILON < Math.PI then 1 else -1
                  | (_, _) -> invalidArg "obj" "not a valid Angle"

      interface IComparable with
         member this.CompareTo obj = 
            match obj with
               | :? Angle as obj -> (this :> IComparable<_>).CompareTo obj
               | _ -> invalidArg "obj" "not an Angle"


      // #endregion

      // #region Operators
      
      /// Add two angles 
      static member (+) (a:Angle, b:Angle) = Angle (a.Radians + b.Radians)
      /// Subtract two angles 
      static member (-) (a:Angle, b:Angle) = Angle (a.Radians - b.Radians)
      /// Multiply angle by value

      static member (*) (a:Angle, value:double) = Angle (a.Radians * value)
      /// Multiply angle by value
      static member (*) (value:double, a:Angle ) = Angle (a.Radians * value)
      /// Divide angle by value
      static member (/) (a:Angle, value:double) = Angle (a.Radians / value)
      
      /// a < b when b is within 180 degrees and they are not equal
      static member op_LessThan (a:Angle, b:Angle) = (a :> IComparable).CompareTo(b) < 0
      /// a <= b when b is within 180 degrees or they are equal
      static member op_LessThanOrEqual (a:Angle, b:Angle) = (a :> IComparable).CompareTo(b) <= 0

      /// a > b when a is within 180 degrees and they are not equal
      static member op_GreaterThan (a:Angle, b:Angle) = (a :> IComparable).CompareTo(b) > 0
      /// a >= b when a is within 180 degrees or they are equal
      static member op_GreaterThanOrEqual (a:Angle, b:Angle) = (a :> IComparable).CompareTo(b) >= 0

      static member op_Equality (a:Angle, b:Angle) = (a :> IComparable).CompareTo(b) = 0
      
      // #endregion