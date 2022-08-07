Framework:
      Stated building framework with language c#
      Build running tool is NUnit
      Used Specflow for writing BDD test cases
      
 PageObjectModel:
      ID's has been used to locate elements on page, where ID's are not available X-Path's has been used
      Pages has been split accross three sections 
        - Locators
        - Constructor
        - Actions
        
  BDD:
      Specflow feature file has been created with test cases
      Step defnitions has been generated and required actions has been called from Page object class
      
   Test Cases:
      Test shas been created thst covers plan my journey business scenarios to cover valid, invalid, errors, Edit journey and planning journey based on arrival time
      
     Improvements:
        Provided with the time scale I would enhance the existing framework to include
          - Dynamic handling of the floating windows
          - Parllel running of the tests
          - Reporting
          
       Test case 06 - Recent journey 
         This currently unstable as Chrome always uses incognito mode even when all cookies are accepted. 
         This can be handled by running more than one journey in the same scenario. 
        
