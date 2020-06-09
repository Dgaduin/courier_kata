We are starting with a simple Domain>Test structure. This won't follow DDD to the core since it requires a concept of identities, which don't seem to appear in the scope of this kata. 

1. We start with an assumption that the measures are whole positive numbers 
2. Parcel behaviour is embedded in the Parcel object 
3. SpeedyShipping has an internal constructor to prevent it from being added to order items without going through the Order object
4. Heavy parcels are going to be treated as separate type of entities, and not a variation, since they don't follow any of the price rules for the other packages
5. On the discounts it seems that we have a somewhat obvious order of execution to get the best overall discount - small and medium discounts, don't intervene with each other, and the mixed parcel, is worse than either the small or medium ones if we only had small or medium parcels s