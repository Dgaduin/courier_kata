We are starting with a simple Domain>Test structure. This won't follow DDD to the core since it requires a concept of identities, which don't seem to appear in the scope of this kata. 

1. We start with an assumption that the measures are whole positive numbers 
2. Parcel behaviour is embedded in the Parcel object 
3. SpeedyShipping has an internal constructor to prevent it from being added to order items without going through the Order object
4. Heavy parcels have only weight as a requirement 